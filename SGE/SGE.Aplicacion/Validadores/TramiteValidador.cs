namespace SGE.Aplicacion;

public static class TramiteValidador
{
    public static bool validar(string? contenido, int idUsuario){
        return (contenido != null)&&(idUsuario > 0);
    }
}
