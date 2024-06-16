namespace SGE.Repositorios;

using Microsoft.EntityFrameworkCore;
using SGE.Aplicacion;

public class RepositorioContext: DbContext{
    public DbSet<Usuario> Usuarios{get; set;}
    public DbSet<Expediente> Expedientes{get; set;}
    public DbSet<Tramite> Tramites{get; set;}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
        optionsBuilder.UseSqlite("data source=Repositorio.sqlite");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        modelBuilder.Entity<Usuario>(entity => {
            entity.HasKey(e => e.IdUsuario);
            entity.Property(e => e.Nombre).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Apellido).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
        });
    }
}
