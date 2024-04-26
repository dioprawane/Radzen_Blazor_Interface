using Microsoft.EntityFrameworkCore;
using DialogueDeGestion.Models; // Assurez-vous que cet espace de noms corresponde à l'emplacement de vos modèles

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Dialogue> Dialogue { get; set; }
}
