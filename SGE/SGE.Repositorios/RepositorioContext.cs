﻿namespace SGE.Repositorios;

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
        //Usuarios
        modelBuilder.Entity<Usuario>().ToTable("Usuarios");
        modelBuilder.Entity<Usuario>()
            .Property(u => u.Nombre) //establece la variable que va a ocupar esa columna
            .HasMaxLength(100) //establece el maximo
            .IsRequired(true); //establece que no puede ser null

        modelBuilder.Entity<Usuario>().Property(u => u.Apellido).HasMaxLength(100).IsRequired(true);
        modelBuilder.Entity<Usuario>().Property(u => u.Email).HasMaxLength(100).IsRequired();
        modelBuilder.Entity<Usuario>().Property(u => u.Password).HasMaxLength(100).IsRequired();
        modelBuilder.Entity<Usuario>(entity => {
            entity.Property(e => e.Permisos)
            .HasConversion( //Configura la conversión de valor para la propiedad Permisos
                v=> string.Join(',', v ?? new List<string>()), //Convierte la lista de cadenas en una sola cadena delimitada por comas para almacenar en la base de datos.
                v=> v.Split(',',StringSplitOptions.RemoveEmptyEntries).ToList()); // Convierte la cadena delimitada por comas de nuevo en una lista de cadenas cuando se recupera de la base de datos.
        });

        //Expedientes
        modelBuilder.Entity<Expediente>().ToTable("Expedientes");
        modelBuilder.Entity<Expediente>().Property(e => e.Caratula).HasMaxLength(1000).IsRequired();
        modelBuilder.Entity<Expediente>().Property(e => e.FechaModificacion).IsRequired();
        modelBuilder.Entity<Expediente>().Property(e => e.FechaCreacion).IsRequired();
        modelBuilder.Entity<Expediente>().HasKey(e => e.Id);
        modelBuilder.Entity<Expediente>().Property(e=>e.IdUsuarioModificador).IsRequired();
        modelBuilder.Entity<Expediente>().Property(e => e.Estado).IsRequired().HasConversion(
            v => v.ToString(),
            v => (EstadoExpediente.Estados)Enum.Parse(typeof(EstadoExpediente.Estados), v)
        );

        modelBuilder.Entity<Tramite>().ToTable("Tramites");
        modelBuilder.Entity<Tramite>().Property(e=>e.IdUsuarioModificador).IsRequired();
        modelBuilder.Entity<Tramite>().Property(e=>e.Contenido).HasMaxLength(1000).IsRequired();
        modelBuilder.Entity<Tramite>().Property(e=>e.ExpedienteId).IsRequired();
        modelBuilder.Entity<Tramite>().Property(e=>e.FechaDeCreacion).IsRequired();
        modelBuilder.Entity<Tramite>().Property(e=>e.FechaDeModificacion).IsRequired();
        modelBuilder.Entity<Tramite>().HasKey(e=>e.id);
        modelBuilder.Entity<Tramite>().Property(e=>e.Etiqueta).HasConversion(
            v => v.ToString(),
            v => (EtiquetaTramite.Etiquetas)Enum.Parse(typeof(EtiquetaTramite.Etiquetas), v)
        );
    }
}
