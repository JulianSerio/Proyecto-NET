namespace SGE.Aplicacion;

public static class ExpedienteValidador
{
    public static bool validar(string? caratula){
        return (!string.IsNullOrEmpty(caratula) && !string.IsNullOrWhiteSpace(caratula));
    }
}
