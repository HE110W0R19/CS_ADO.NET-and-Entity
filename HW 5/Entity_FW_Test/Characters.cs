namespace SQL_DBModel_CMD
{
    internal class Characters
    {
        public int Id { get; private set; }
        public string Name{ get; private set; }
        public int CharacterClassId{ get; private set; }

        //public Characters(int id, string name, int fK_CharacterClass)
        //{
        //    Id = id;
        //    Name = name;
        //    CharacterClassId = fK_CharacterClass;
        //}
    }
}
