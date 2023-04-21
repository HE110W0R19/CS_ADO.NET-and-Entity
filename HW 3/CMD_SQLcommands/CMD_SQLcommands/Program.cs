using MySql.Data.MySqlClient;
using System;
using System.Data.Common;

namespace CMD_SQLcommands
{
    internal class Program
    {
        private static bool InsertNewPerson_SQL(MySqlConnection DBConnection,string PersName, string PersClass, Int16 ClassStatus)
        {
            MySqlCommand cmd = null;
            try
            {
                if(ClassStatus == 1) 
                {
                    string SQLInsertPersonCommand = $"INSERT INTO Characters(Name, CharacterClassId) " +
                        $"SELECT \"{PersName}\", cc.Id " +
                        $"FROM CharactersClass AS cc WHERE cc.Name = \"{PersClass}\";";

                    cmd = new MySqlCommand(SQLInsertPersonCommand, DBConnection);
                    cmd.BeginExecuteNonQuery();
                    return true;
                }
                else if(ClassStatus == 0)
                {
                    string SQLInsertClassCommand = $"INSERT INTO CharactersClass(Name)\r\nVALUES (\"{PersClass}\");";

                    string SQLInsertPersonCommand = $"INSERT INTO Characters(Name, CharacterClassId)\r\n" +
                        $"SELECT \"{PersName}\", cc.Id\r\n" +
                        $"FROM CharactersClass AS cc\r\n" +
                        $"WHERE cc.Name = \"{PersClass}\";";

                    cmd = new MySqlCommand(SQLInsertClassCommand + "\n" + SQLInsertPersonCommand, DBConnection);
                    cmd.BeginExecuteNonQuery();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception e) 
            {
                Console.WriteLine(e.ToString());
                return false;
            }
            finally
            {
                if (cmd != null)
                {
                    cmd.Cancel();
                }
            }
        }
        private static Int16 FindClass_SQL(MySqlConnection DBConnection, string ClassType)
        {
            int counter = -1;
            MySqlCommand cmd = null;
            MySqlDataReader SQLreader = null;
            string FindClassSQLcommand =
                $"SELECT COUNT(CharactersClass.Name) AS \"FindedCLassCount\" " +
                $"FROM `CharactersClass` " +
                $"WHERE CharactersClass.Name = \"{ClassType}\";";
            try
            {
                cmd = new MySqlCommand(FindClassSQLcommand, DBConnection);
                SQLreader = cmd.ExecuteReader();

                while (SQLreader.Read())
                {
                    counter = Convert.ToInt16(SQLreader[0]);
                }

                if (counter >= 1)
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
                if (cmd != null)
                {
                    cmd.Cancel();
                }
            }
        }
        static void Main(string[] args)
        {
            string SelectSQLcommand = @"SELECT c.Name AS ""Person Name"", cc.Name AS ""Class Name"" 
                                        FROM Characters AS c, CharactersClass AS cc 
                                        WHERE c.CharacterClassId = cc.Id;";
            string PersonName = null;
            string PersonClass = null;

            MySqlConnection connection = null;
            MySqlDataReader reader = null;
            MySqlConnectionStringBuilder mySqlConnectionStringBuilder = new MySqlConnectionStringBuilder()
            {
                Server = "db4free.net",
                Database = "first_test_db",
                UserID = "anonim",
                Password = "anonim228",
            };

            try
            {
                connection = new MySqlConnection(mySqlConnectionStringBuilder.ToString());

                Console.WriteLine("Enter Person Name: ");
                PersonName = Console.ReadLine();

                Console.WriteLine("Enter Person Class: ");
                PersonClass = Console.ReadLine();

                Console.Clear();

                connection.Open();

                Int16 ClassExists = FindClass_SQL(connection, PersonClass);

                bool InsertStatus = InsertNewPerson_SQL(connection, PersonName, PersonClass, ClassExists);

                if (InsertStatus) 
                {
                    MySqlCommand cmd = new MySqlCommand(SelectSQLcommand, connection);

                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Console.WriteLine(reader[0] + " " + reader[1]);
                    }

                }

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadKey();
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }
    }
}
