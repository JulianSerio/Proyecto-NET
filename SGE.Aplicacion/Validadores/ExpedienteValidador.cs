namespace SGE.Aplicacion;

public static class ExpedienteValidador
{
    public static void validar(string? caratula, int idUsuario){
        if(!((!string.IsNullOrEmpty(caratula) && !string.IsNullOrWhiteSpace(caratula))&&(idUsuario > 0))){
            throw new ValidacionException(); //si no cumple envia la excepcion
        }
    }
}
