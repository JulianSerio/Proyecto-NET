using System.Collections;
using System.Reflection.Emit;

namespace SGE.Aplicacion;

public class Usuario
{
    private string? _nombre;
    private string? _apellido;
    private string? _correoElectronico;
    private string? _contraseña;
    private List<Permiso> _permisos;
    private bool _admin;
    
    public Usuario(string nombre, string apellido, string correoElectronico, string contraseña, bool admin){
        _permisos = new List<Permiso>(); //se instancian vacios los permisos

        _nombre=nombre;
        _apellido=apellido;
        _correoElectronico=correoElectronico;
        _contraseña=contraseña;
        _admin=admin; //se tiene que evaluar esto
    }
}
