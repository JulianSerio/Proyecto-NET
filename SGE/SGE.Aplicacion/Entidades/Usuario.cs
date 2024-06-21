namespace SGE.Aplicacion;

public class Usuario
{
    public string? Nombre {get;set;}
    public string? Apellido {get;set;}
    public string? Email {get;set;}
    public string? Password {get;set;}
    public List<Permiso.Permisos>? Permisos {get;set;}
    public int? IdUsuario{get;set;}

    public Usuario(string nombre, string apellido, string? email, string password){
        Permisos = new List<Permiso.Permisos>(); //se instancian vacios los permisos
        Nombre = nombre;
        Apellido = apellido;
        Email = email;
        Password = password;
    }

    public Usuario(string nombre, string apellido, string? email, string password, int idUsuario, List<Permiso.Permisos>? permisos){
        Permisos = permisos;
        Nombre=nombre;
        Apellido=apellido;
        Email=email;
        Password=password;
        IdUsuario = idUsuario;
    }
}