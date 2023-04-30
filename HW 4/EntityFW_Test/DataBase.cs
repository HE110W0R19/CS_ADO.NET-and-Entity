using System;
using System.Collections.Generic;
using System.Linq;

namespace SQL_DBModel_CMD
{

    internal static class DataBase
    {
        public static List<Characters> Characters { get; private set; }
        public static List<CharactersClass> CharactersClass { get; private set; }
        public static List<CharacterClassBuild> CharacterClassBuild { get; private set; }
        public static List<Spell> Spell { get; private set; }

        public static void InitStaticDb()
        {
            IReadOnlyCollection<Characters> CHARACTERS = new List<Characters>()
            {
                new Characters(1,"Person 1", 1),
                new Characters(2, "Person 2", 1),
                new Characters(3,"Person 3", 2),
                new Characters(4,"Person 4", 2)
            };

            IReadOnlyCollection<CharactersClass> CHARACTERS_CLASS = new List<CharactersClass>()
            {
                new CharactersClass(1,"Class 1"),
                new CharactersClass(2, "Class 2")
            };

            IReadOnlyCollection<Spell> SPELLS = new List<Spell>()
            {
                new Spell(1,"Spell 1"),
                new Spell(2, "Spell 2")
            };

            IReadOnlyCollection<CharacterClassBuild> CHARACTER_CLASS_BUILD = new List<CharacterClassBuild>()
            {
                new CharacterClassBuild(1,1,1),
                new CharacterClassBuild(2, 2, 2),
            };

            Characters = CHARACTERS.ToList();
            CharactersClass = CHARACTERS_CLASS.ToList();
            Spell = SPELLS.ToList();
            CharacterClassBuild = CHARACTER_CLASS_BUILD.ToList();
        }

        public static void Select_PlayerNames()
        {
            var result = Characters.Select(x => x.Name).ToList();

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        public static void Select_PlayerNameClassName() 
        {
            var result =
                Characters.Select((x) => new Tuple<string, string>(
                    x.Name,
                    CharactersClass.First((y) => y.Id == x.CharacterClassId).Name)
                    ).ToList();

            foreach(var item in result)
            {
                Console.WriteLine(item);
            }
        }

        public static void Select_ClassNameSpellName()
        {
            var result =
                CharacterClassBuild.Select((x) => (new Tuple<string, string>
                (
                    CharactersClass.First((i) => x.CharacterClassId == i.Id).Name,
                    Spell.First((j) => x.CharacterClassId == j.Id).Name))
                ).ToList();

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        public static void Select_PlaerNameSpellName()
        {
            var result =
                CharacterClassBuild.Select((x) => (new Tuple<string, string>
                (
                    Characters.First((i) => i.CharacterClassId ==
                    CharactersClass.First((j) => j.Id == i.CharacterClassId).Id).Name,
                    Spell.First((y) => y.Id == x.CharacterClassId).Name))
                ).ToList();

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
