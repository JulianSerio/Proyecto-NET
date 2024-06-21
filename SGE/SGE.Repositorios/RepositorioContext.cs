namespace SGE.Repositorios;
using SGE.Aplicacion;
using Microsoft.EntityFrameworkCore;
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
        modelBuilder.Entity<Usuario>().HasKey(u => u.IdUsuario); // Definiendo la clave primaria
        modelBuilder.Entity<Usuario>()
            .Property(u => u.Nombre) //establece la variable que va a ocupar esa columna
            .HasMaxLength(100) //establece el maximo
            .IsRequired(true); //establece que no puede ser null

        modelBuilder.Entity<Usuario>().Property(u => u.Apellido).HasMaxLength(100).IsRequired(true);
        modelBuilder.Entity<Usuario>().Property(u => u.Email).HasMaxLength(100).IsRequired();
        modelBuilder.Entity<Usuario>().Property(u => u.Password).HasMaxLength(100).IsRequired();
        modelBuilder.Entity<Usuario>()
        .Property(u => u.Permisos)
        .HasConversion(
            permisos => permisos != null ? string.Join(",", permisos.Select(p => p.ToString())) : "", // Convert List<Permiso.Permisos> to string
            permisosString => permisosString.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                            .Select(p => Enum.Parse<Permiso.Permisos>(p))
                                            .ToList()                         // Convert string to List<Permiso.Permisos>
        );

        //Expedientes
        modelBuilder.Entity<Expediente>().ToTable("Expedientes");
        modelBuilder.Entity<Expediente>().Property(e => e.Caratula).HasMaxLength(1000).IsRequired();
        modelBuilder.Entity<Expediente>().Property(e => e.FechaModificacion).IsRequired();
        modelBuilder.Entity<Expediente>().Property(e => e.FechaCreacion).IsRequired();
        modelBuilder.Entity<Expediente>().HasKey(e => e.Id);
        modelBuilder.Entity<Expediente>().Property(e=>e.IdUsuarioModificador).IsRequired();
        modelBuilder.Entity<Expediente>().Property(e => e.Estado).IsRequired().HasConversion(
            v => v.ToString(), // Convert Enum to string
            v => string.IsNullOrEmpty(v) ? default(EstadoExpediente.Estados?) : Enum.Parse<EstadoExpediente.Estados>(v)
        );

        modelBuilder.Entity<Tramite>().ToTable("Tramites");
        modelBuilder.Entity<Tramite>().Property(e=>e.IdUsuarioModificador).IsRequired();
        modelBuilder.Entity<Tramite>().Property(e=>e.Contenido).HasMaxLength(1000).IsRequired();
        modelBuilder.Entity<Tramite>().Property(e=>e.FechaCreacion).IsRequired();
        modelBuilder.Entity<Tramite>().Property(e=>e.FechaModificacion).IsRequired();
        modelBuilder.Entity<Tramite>().HasKey(e=>e.Id);
        modelBuilder.Entity<Tramite>().Property(e=>e.EtiquetaTramite).HasConversion(
            v => v.ToString(),
            v => (EtiquetaTramite.Etiquetas)Enum.Parse(typeof(EtiquetaTramite.Etiquetas), v)
        );
        // Configuración de la relación entre Expediente y Tramite usando solo la clave externa
        modelBuilder.Entity<Tramite>()
            .HasOne<Expediente>()
            .WithMany()
            .HasForeignKey(t => t.ExpedienteId)
            .OnDelete(DeleteBehavior.Cascade);
        }
}

