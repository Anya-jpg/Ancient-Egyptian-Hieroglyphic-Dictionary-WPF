using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EgyptianDictionary.Entities
{
    class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=Mobile.db");
        }
        public DbSet<Categoria> Categorias { get; set; }
            public DbSet<Dictionary> Dictionaries { get; set; }
            public DbSet<Phonogram> Phonograms { get; set; }
            public DbSet<Pharaoh> Pharaohs { get; set; }
            public DbSet<User> Users { get; set; }
            public DbSet<Client> Clients { get; set; }
            public DbSet<Translator> Translators { get; set; }
            public DbSet<Translation> Translations { get; set; }
            public DbSet<Role> Roles { get; set; }

        }
 
}
