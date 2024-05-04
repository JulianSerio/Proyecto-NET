namespace SGE.Aplicacion;

public class ValidacionException : Exception
{
    public ValidacionException() : base("La entidad no cumple con los requisitos exigidos.") { }

    public ValidacionException(string mensaje) : base(mensaje) { }

    public ValidacionException(string mensaje, Exception innerException) : base(mensaje, innerException) { }
}
