using Characters_Info_WithEntity.EntityModels;

namespace ProgramMain
{
    class ProgramMain
    {
        public static void Main(string[] args)
        {
            getAllInfo_ForCharacter();
            Console.WriteLine("======= AFTER =======");
            lvlUp_ForCharacter(1, "Убивака", "Пинок");
            getAllInfo_ForCharacter();
        }

#pragma warning disable CS8602 // Разыменование вероятной пустой ссылки.
        public static void getAllInfo_ForCharacter()
        {
            try
            {
                using (FirstTestDbContext EntityData = new FirstTestDbContext())
                {
                    var characterAllInfo = EntityData.Characters.Select((x) => new
                    {
                        characterId = x.Id,
                        characterName = x.Name,
                        className = x.CharacterClass.Name,

                        spels = x.CharacterClass.CharacterClassBuilds.Select((y) => new
                        {
                            y.Spell.Name,
                            y.Spell.Expirience.CurrentLevel,
                            y.Spell.Expirience.NextLevelExpirience
                        }).ToList(),
                    }).ToList();

                    foreach (var character in characterAllInfo)
                    {
                        Console.WriteLine($"\n\n...Id: {character.characterId}\n" +
                            $"...Name: {character.characterName}\n" +
                            $"...Class: {character.className}\n" +
                            $"......Spels:");

                        foreach (var spels in character.spels)
                        {
                            Console.WriteLine($"...spel \"{spels.Name}\" (Current lvl: {spels.CurrentLevel} -> Next lvl: {spels.NextLevelExpirience})");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //Хэлп! Не работает(
        public static void lvlUp_ForCharacter(int characterId, string characterName, string spellName)
        {
            try
            {
                using (FirstTestDbContext EntityData = new FirstTestDbContext())
                {
                    EntityData.Characters.Select(w => new { w.Id, w.Name, w.CharacterClass.CharacterClassBuilds })
                        .Where(q => q.Id == characterId && q.Name == characterName)
                        .FirstOrDefault().CharacterClassBuilds
                        .Select(e => new { e.Spell.Name, e.Spell.Expirience }).Where(s => s.Name == spellName)
                        .FirstOrDefault().Expirience.CurrentLevel += 1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void lvlDown_ForCharacter(int characterId, string characterName, string spellName)
        {
            try
            {
                using (FirstTestDbContext EntityData = new FirstTestDbContext())
                {
                    EntityData.Characters.Select(w => new { w.Id, w.Name, w.CharacterClass.CharacterClassBuilds })
                        .Where(q => q.Id == characterId && q.Name == characterName)
                        .FirstOrDefault().CharacterClassBuilds
                        .Select(e => new { e.Spell.Name, e.Spell.Expirience }).Where(s => s.Name == spellName)
                        .FirstOrDefault().Expirience.CurrentLevel -= 1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
#pragma warning restore CS8602 // Разыменование вероятной пустой ссылки.
    }
}