using Entity_FW_Test;
using Microsoft.EntityFrameworkCore;

namespace MySQLApp
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "host = db4free.net; username = anonim; password = anonim228; database = first_test_db;",
                new MySqlServerVersion(new Version(8, 0, 11))
            );
        }
    }
}

namespace SQL_DBModel_CMD
{

    internal class DataBase : DbContext
    {
        public DbSet<Characters> Characters { get; private set; }
        public DbSet<CharactersClass> CharactersClass { get; private set; }
        public DbSet<CharacterClassBuild> CharacterClassBuild { get; private set; }
        public DbSet<Spell> Spell { get; private set; }
        public DbSet<CharactersExpirience> CharactersExpirience { get; private set; }
        public DbSet<Expirience> Expirience { get; private set; }

        public DataBase()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "host = db4free.net; username = anonim; password = anonim228; database = first_test_db;",
                new MySqlServerVersion(new Version(8, 0, 11))
            );
        }
    }
}
