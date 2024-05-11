namespace SGE.Aplicacion;

public static class TramiteValidador
{
    public static bool validar(string? contenido, int idUsuario){
        return ((!string.IsNullOrEmpty(contenido) && !string.IsNullOrWhiteSpace(contenido))&&(idUsuario > 0));
    }
}
