namespace SGE.Aplicacion;

public static class TramiteValidador
{
    public static bool validar(string? contenido){
        return (!string.IsNullOrEmpty(contenido) && !string.IsNullOrWhiteSpace(contenido));
    }
}
