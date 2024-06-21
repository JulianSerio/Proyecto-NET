using System.Security;

namespace SGE.Aplicacion;

//
// Summary:
//     Envia los datos necesarios al repositorio de usuarios para una nueva instancia de un usuario
//
public class CasoDeUsoUsuarioAlta (IUsuarioRepositorio repo, UsuarioValidador validador, ServicioAutorizacion autorizacion){
    public void Ejecutar(string nombre, string apellido, string email, string password){ //no hace falta tirar excepciones porque en la UI se tiene que verificar que todos los campos esten completos
        if(validador.Validar(email)){ //valida que el Email no exista en el repositorio
            string passwordPasadaPorHash = ServicioFuncionHash.FuncionHashSHA256(password);
            int? idUsuario = repo.UsuarioAlta(nombre, apellido, email, passwordPasadaPorHash); 
            if(autorizacion.EsAdmin(idUsuario)){
                List<Permiso.Permisos> permisos = new List<Permiso.Permisos>{Permiso.Permisos.ExpedienteBaja,Permiso.Permisos.ExpedienteAlta,Permiso.Permisos.ExpedienteModificacion,Permiso.Permisos.TramiteAlta,Permiso.Permisos.TramiteBaja,Permiso.Permisos.TramiteModificacion};
                repo.UsuarioModicacion(idUsuario,nombre, apellido, email, passwordPasadaPorHash, permisos);
            }
        }else{
            throw new ValidacionException("El email ingresado ya se encuentra registrado en la base de datos");
        }
    }
}
