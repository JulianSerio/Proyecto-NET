namespace SGE.Aplicacion;

public class Usuario
{
    private string? _nombre;
    private string? _apellido;
    private string? _email;
    private string? _password;
    private List<string>? _permisos;
    private int? _idUsuario;

    public Usuario(string nombre, string apellido, string? email, string password){
        _permisos = new List<string>(); //se instancian vacios los permisos
        Nombre = nombre;
        Apellido = apellido;
        _email = email;
        Password = password;
    }

    public Usuario(string nombre, string apellido, string? email, string password, int idUsuario){
        _permisos = new List<string>(); //se instancian vacios los permisos
        _nombre=nombre;
        _apellido=apellido;
        _email=email;
        _password=password;//se tiene que evaluar esto
        _idUsuario = idUsuario;
    }

    public string? Email{get;}
    public int? IdUsuario{get;}
    public string? Apellido {get;}
    public string? Password {get;}
    public List<string>? Permisos {get;set;}
    public string? Nombre {get;}    
}
