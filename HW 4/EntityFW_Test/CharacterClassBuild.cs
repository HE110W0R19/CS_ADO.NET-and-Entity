namespace SQL_DBModel_CMD
{
    internal class CharacterClassBuild
    {
        public int Id { get; private set; }
        public int SpellId { get; private set; }
        public int CharacterClassId { get; private set; }

        public CharacterClassBuild(int id, int fK_Spell, int fK_CharacterClassId)
        {
            Id = id;
            SpellId = fK_Spell;
            CharacterClassId = fK_CharacterClassId;
        }
    }
}
