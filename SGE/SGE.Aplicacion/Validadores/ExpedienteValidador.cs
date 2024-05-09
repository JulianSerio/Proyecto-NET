namespace SGE.Aplicacion;

public static class ExpedienteValidador
{
    public static bool validar(string? caratula, int idUsuario){
        return (((caratula != null)&&(caratula != ""))&&(idUsuario > 0)); //si la caratula no esta vacia, no es null y el id del usuario es mayor a 0 retorna verdadero
    }
}
