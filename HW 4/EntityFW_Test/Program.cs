using SQL_DBModel_CMD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFW_Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataBase.InitStaticDb();

            Console.WriteLine("\n...Request 1\n");
            DataBase.Select_PlayerNames();

            Console.WriteLine("\n...Request 2\n");
            DataBase.Select_PlayerNameClassName();

            Console.WriteLine("\n...Request 3\n");
            DataBase.Select_PlaerNameSpellName();
            
            Console.WriteLine("\n...Request 4\n");
            DataBase.Select_ClassNameSpellName();
            
            Console.ReadKey();
        }
    }
}
