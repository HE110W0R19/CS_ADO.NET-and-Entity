using MySQLApp;
using SQL_DBModel_CMD;
using System.Globalization;

namespace Entity_FW_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            using (DataBase db = new DataBase())
            {
                Select_ClassNameSpellName(db);
                Console.ReadKey();
            }
        }

        //+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        //Home Work Requests
        //+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        public static void Select_PlayerNames(DataBase data)
        {
            var result = data.Characters.Select(x => x.Name).ToList();

            foreach(var item in result)
            {
                Console.WriteLine(item);
            }
        }

        public static void Select_ClassNameSpellName(DataBase data)
        {
            var result =
                data.CharacterClassBuild.Select((x) => (new Tuple<string,string> 
                (
                    data.CharactersClass.First((i) => x.CharacterClassId == i.Id).Name,
                    data.Spell.First((j) => x.CharacterClassId == j.Id).Name))
                ).ToList();

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        public static void Select_PlaerNameSpellName(DataBase data)
        {
            var result =
                data.CharacterClassBuild.Select((x) => (new Tuple<string, string>
                (
                    data.Characters.First((i) => i.CharacterClassId == 
                    data.CharactersClass.First((j) => j.Id == i.CharacterClassId).Id).Name,
                    data.Spell.First((y) => y.Id == x.CharacterClassId).Name))
                ).ToList();

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
        //+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
        //End Home Work Requests
        //+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
    }


}