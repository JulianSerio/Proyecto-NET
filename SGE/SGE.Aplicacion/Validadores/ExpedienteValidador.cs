namespace SGE.Aplicacion;

public static class ExpedienteValidador
{
    public static bool validar(string? caratula, int idUsuario){
        return ((caratula != null)&&(idUsuario > 0));
    }
}
