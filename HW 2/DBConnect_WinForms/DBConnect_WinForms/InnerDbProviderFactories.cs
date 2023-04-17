using System.Data;
using System.Data.Common;
using MySql.Data.MySqlClient;

namespace DataBase_ADO_.NET
{
    public static class InnerDbProviderFactories
    {
        public static DataTable GetFactoryClasses()
        {
            var factoryClasses = DbProviderFactories.GetFactoryClasses();
            var mySqlRow = factoryClasses.NewRow();

            mySqlRow["Name"] = "Microsoft MySQL Server Compact Data Provider";
            mySqlRow["Description"] = ".NET Framework Data Provider for My SQL Server";
            mySqlRow["InvariantName"] = "MySql.Data";
            mySqlRow["AssemblyQualifiedName"] =
                "MySql.Data.MySqlClient.MySqlClientFactory, MySql.Data, Version=8.0.32.0, Culture=neutral, PublicKeyToken=c5687fc88969c44d";

            factoryClasses.Rows.Add(mySqlRow);


            return factoryClasses;
        }

        public static DbProviderFactory GetFactory(string invariantName)
        {
            switch (invariantName)
            {
                case "MySql.Data":
                    return new MySqlClientFactory();
                default:
                    return DbProviderFactories.GetFactory(invariantName);
            }
        }
    }
}