namespace SGE.Aplicacion;

public class AutorizacionException : Exception
{
    public AutorizacionException() : base("No tiene los permisos necesarios para realizar esta operación.") { }

    public AutorizacionException(string mensaje) : base(mensaje) { }

    public AutorizacionException(string mensaje, Exception innerException) : base(mensaje, innerException) { }
}
