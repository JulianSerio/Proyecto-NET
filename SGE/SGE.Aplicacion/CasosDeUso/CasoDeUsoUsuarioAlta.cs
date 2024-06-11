namespace SGE.Aplicacion;

//
// Summary:
//     Envia los datos necesarios al repositorio de usuarios para una nueva instancia de un usuario
//
public class CasoDeUsoUsuarioAlta (IUsuarioRepositorio repo){
    public void Ejecutar(string nombre, string apellido, string email, string password){ //no hace falta tirar excepciones porque en la UI se tiene que verificar que todos los campos esten completos
        var validador = new UsuarioValidador(repo); //no creo que este bien del todo CONSULTAR
        if(validador.Validar(email)){ //valida que el Email no exista en el repositorio
            string passwordPasadaPorHash = ServicioFuncionHash.FuncionHashSHA256(password);
            repo.UsuarioAlta(nombre, apellido, email, passwordPasadaPorHash); 
        }
    }
}
