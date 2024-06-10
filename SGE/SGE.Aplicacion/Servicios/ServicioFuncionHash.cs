namespace SGE.Aplicacion;
using System.Security.Cryptography;
using System.Text;

public static class ServicioFuncionHash{

    public static String FuncionHashSHA256(string password){

        // Convertir la contraseña a un arreglo de bytes utilizando UTF-8
        byte[] passwordEnBytes = Encoding.UTF8.GetBytes(password);

        // Crear una instancia de SHA256
        using (SHA256 funcionSHA256 = SHA256.Create()){

            // Calcular el hash de la contraseña
            byte[] hashBytes = funcionSHA256.ComputeHash(passwordEnBytes);
            
            // Convertir el hash a una cadena hexadecimal
            string passwordPasadaPorHash = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();

            return passwordPasadaPorHash;
        }

        
    }
}
