//MODIFICA
using Gestionale_Libreria.Models;
using Microsoft.EntityFrameworkCore;

class Database : DbContext
{
    public Database(DbContextOptions options) : base(options) { }
    public DbSet<Libro> Libri { get; set; } = null!;
    public DbSet<Genere> Generi { get; set; } = null!;
    public DbSet<Scaffale> Libreria { get; set; } = null!;

}