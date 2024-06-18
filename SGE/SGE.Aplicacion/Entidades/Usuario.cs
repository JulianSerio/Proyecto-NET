namespace SGE.Aplicacion;

public class Usuario
{
    public string? Nombre {get;set;}
    public string? Apellido {get;set;}
    public string? Email {get;set;}
    public string? Password {get;set;}
    public List<string>? Permisos {get;set;}
    public int? IdUsuario{get;set;}

    public Usuario(){}
    public Usuario(string nombre, string apellido, string? email, string password){
        Permisos = new List<string>(); //se instancian vacios los permisos
        Nombre = nombre;
        Apellido = apellido;
        Email = email;
        Password = password;
    }

    public Usuario(string nombre, string apellido, string? email, string password, int idUsuario){
        Permisos = new List<string>(); //se instancian vacios los permisos
        Nombre=nombre;
        Apellido=apellido;
        Email=email;
        Password=password;//se tiene que evaluar esto
        IdUsuario = idUsuario;
    }

/*
    public string? Email{get;}
    public int? IdUsuario{get;}
    public string? Apellido {get;}
    public string? Password {get;}
    public List<string>? Permisos {get;set;}
    public string? Nombre {get;}    
    */
}