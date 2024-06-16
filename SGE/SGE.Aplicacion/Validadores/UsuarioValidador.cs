namespace SGE.Aplicacion;

public class UsuarioValidador(IUsuarioRepositorio repo){
    public bool Validar(string? email){
        return repo.EmailRepetido(email);
    }
}
