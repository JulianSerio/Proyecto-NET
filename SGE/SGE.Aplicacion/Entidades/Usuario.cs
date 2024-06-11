using System.Collections;
using System.Reflection.Emit;

namespace SGE.Aplicacion;

public class Usuario
{
    private string _nombre;
    private string _apellido;
    private string _email;
    private string _contraseña;
    private List<Permiso> _permisos;
    private int _idUsuario;
    private bool _admin;
    
    public Usuario(string nombre, string apellido, string email, string contraseña, int idUsuario){
        _permisos = new List<Permiso>(); //se instancian vacios los permisos
        _nombre=nombre;
        _apellido=apellido;
        _email=email;
        _contraseña=contraseña;//se tiene que evaluar esto
        if(idUsuario == 1){
            _admin = true; //si el ID recibido es 1, ese usuario es admin
        }
         _idUsuario = idUsuario;
    }
    
    public bool Admin{
        get => _admin;
    }
    
}
