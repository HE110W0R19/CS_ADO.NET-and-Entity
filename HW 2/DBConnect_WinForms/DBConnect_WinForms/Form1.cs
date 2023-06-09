﻿using MySqlX.XDevAPI.Relational;
using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace DBConnect_WinForms
{

    public partial class Form1 : Form
    {
        //MySqlConnection connection = null;
        //MySqlProviderFactory factory = null;
        DbConnection connection = null;
        DbProviderFactory factory = null;
        DataTable dt = null;
        string providerName = "";
        string personName = null;
        string personClass = null;
        public Form1()
        {
            InitializeComponent();
        }

        static string GetConnectionStrByProvider(string providerName)
        {
            ConnectionStringSettingsCollection connectionStrings = ConfigurationManager.ConnectionStrings;
            if (connectionStrings != null)
            {
                foreach (ConnectionStringSettings connectionString in connectionStrings)
                {
                    if (connectionString.ProviderName == providerName)
                    {
                        return connectionString.ConnectionString;
                    }
                }
            }
            return null;
        }

        private void getProviders_Button_Click(object sender, EventArgs e)
        {
            DataTable table = DataBase_ADO_.NET.InnerDbProviderFactories.GetFactoryClasses();
            //DataTable table = DbProviderFactories.GetFactoryClasses();
            dataGridView1.DataSource = table;
            comboBox1.Items.Clear();
            foreach (DataRow DRow in table.Rows)
            {
                comboBox1.Items.Add(DRow["invariantName"]);
            }
        }

        private void ExecRequest_Button_Click(object sender, EventArgs e)
        {

            DbDataAdapter adapter = factory.CreateDataAdapter();

            adapter.SelectCommand = connection.CreateCommand();
            adapter.SelectCommand.CommandText = SQLRequest_TextBox.Text.ToString();
            connection.ConnectionString = ConnectionString_TextBox.Text.ToString();

            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = table;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            factory = DataBase_ADO_.NET.InnerDbProviderFactories.GetFactory(comboBox1.SelectedItem.ToString());
            //MySqlProviderFactory mySqlProviderFactory = new MySqlProviderFactory();
            connection = factory.CreateConnection();
            providerName = GetConnectionStrByProvider(comboBox1.SelectedItem.ToString());
            ConnectionString_TextBox.Text = providerName;
        }

        private async void CreatePersonButton_Click(object sender, EventArgs e)
        {
            connection.ConnectionString = ConnectionString_TextBox.Text.ToString();
            await Task.Run(() =>
            {
                DbDataAdapter adapter = factory.CreateDataAdapter();
                adapter.SelectCommand = connection.CreateCommand();
                Int16 ClassStatus = FindClass_SQL(adapter, this.personClass);

                bool inserStatus = InsertNewPerson_SQL(adapter, this.personName, this.personClass, ClassStatus);

                if (inserStatus)
                {
                    adapter.SelectCommand.CommandText = @"SELECT c.Name AS ""Person Name"", cc.Name AS ""Class Name"" 
                                                          FROM Characters AS c, CharactersClass AS cc 
                                                          WHERE c.CharacterClassId = cc.Id;";

                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dt = table;
                }
            });
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dt;
        }

        private bool InsertNewPerson_SQL(DbDataAdapter adapter, string PersName, string PersClass, Int16 ClassStatus)
        {
            adapter.SelectCommand = connection.CreateCommand();
            try
            {
                if (ClassStatus == 1)
                {
                    string SQLInsertPersonCommand = $"INSERT INTO Characters(Name, CharacterClassId) " +
                        $"SELECT \"{PersName}\", cc.Id " +
                        $"FROM CharactersClass AS cc WHERE cc.Name = \"{PersClass}\";";

                    adapter.SelectCommand.CommandText = SQLInsertPersonCommand;
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    //adapter.SelectCommand.ExecuteNonQuery();
                    return true;
                }
                else if (ClassStatus == 0)
                {
                    string SQLInsertClassCommand = $"INSERT INTO CharactersClass(Name)\r\nVALUES (\"{PersClass}\");";

                    string SQLInsertPersonCommand = $"INSERT INTO Characters(Name, CharacterClassId)\r\n" +
                        $"SELECT \"{PersName}\", cc.Id\r\n" +
                        $"FROM CharactersClass AS cc\r\n" +
                        $"WHERE cc.Name = \"{PersClass}\";";
                    adapter.SelectCommand.CommandText = SQLInsertClassCommand + "\n" + SQLInsertPersonCommand;

                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    //adapter.SelectCommand.ExecuteNonQuery();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        private Int16 FindClass_SQL(DbDataAdapter adapter, string ClassType)
        {
            DbDataReader SQLreader = null;
            adapter.SelectCommand = connection.CreateCommand();
            string FindClassSQLcommand =
                $"SELECT COUNT(CharactersClass.Name) AS \"FindedCLassCount\" " +
                $"FROM `CharactersClass` " +
                $"WHERE CharactersClass.Name = \"{ClassType}\";";
            try
            {
                adapter.SelectCommand.CommandText = FindClassSQLcommand;
                //SQLreader = adapter.SelectCommand.ExecuteReader();
                //while (SQLreader.Read())
                //{
                //    counter = Convert.ToInt16(SQLreader[0]);
                //}
                DataTable table = new DataTable();
                adapter.Fill(table);
                if (Convert.ToUInt16(table.Rows[0].ItemArray[0]) >= 1)
                {
                    return 1; //Such a class exists
                }
                else
                {
                    return 0; //No such class exists
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1; //Error number
            }
            finally
            {
                if (SQLreader != null)
                {
                    SQLreader.Close();
                }
            }
        }

        private void InputPersName_TB_TextChanged(object sender, EventArgs e)
        {
            this.personName = this.InputPersName_TB.Text;
        }

        private void inputPersClass_TB_TextChanged(object sender, EventArgs e)
        {
            this.personClass = this.inputPersClass_TB.Text;
        }
    }
}
