using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Gestionale_Libreria.Models;

namespace Gestionale_Libreria.Data
{
    class LibreriaDBContext : DbContext
    {
        public DbSet<Libro> Libri {  get; set; }
        public DbSet<Scaffale> Libreria { get; set; }
        public DbSet<Genere> Generi { get; set; }

        //connessione con il database
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=LibreriaDatabase;Trusted_Connection=True;");
        }
    }
}
