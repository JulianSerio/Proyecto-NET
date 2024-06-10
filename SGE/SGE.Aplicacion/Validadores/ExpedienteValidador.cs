namespace SGE.Aplicacion;

public static class ExpedienteValidador
{
    public static bool validar(string? caratula, int idUsuario){
        return ((!string.IsNullOrEmpty(caratula) && !string.IsNullOrWhiteSpace(caratula))&&(idUsuario > 0));
    }
}
