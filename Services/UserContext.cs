using Microsoft.EntityFrameworkCore;
using Domain;

namespace Services
{
    public class UserContext : DbContext
    {
        private const string connectionString = "server=localhost;port=3306;database=UsersDB;user=root;password=12345678Aa";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(connectionString, MariaDbServerVersion.AutoDetect(connectionString));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(e => e.Id);
            modelBuilder.Entity<User>().HasMany<Contact>(e => e.Contacts);

            modelBuilder.Entity<Contact>().HasKey(e => new { e.Id, e.UserIdNum });
            modelBuilder.Entity<Contact>().HasMany<Message>(e => e.ChatWithContact);

            modelBuilder.Entity<Message>().HasKey(e => new { e.Id, e.ContactIdNum, e.UserIdNum1 });

        }
        public DbSet<User> Usersdb { get; set; }
        public DbSet<Contact> Contactsdb { get; set; }
        public DbSet<Message> Messagesdb { get; set; }
    }
}
