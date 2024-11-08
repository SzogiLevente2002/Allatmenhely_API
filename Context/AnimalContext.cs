using Allatmenhely_API.Entities;
using Microsoft.EntityFrameworkCore;

public class AnimalContext : DbContext
{
    public AnimalContext(DbContextOptions<AnimalContext> options) : base(options) { }

    public DbSet<Allatok> Allatoks { get; set; }
    public DbSet<Gondozok> Gondozoks { get; set; }
    public DbSet<Orokbefogadasok> Orokbefogadasoks { get; set; }

}