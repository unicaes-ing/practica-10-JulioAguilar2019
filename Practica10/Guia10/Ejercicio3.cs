using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Guia10
{
    class Ejercicio3
    {
        public static FileStream fs = new FileStream(@"C:\Users\Usuario\encriptacion.txt", FileMode.OpenOrCreate,FileAccess.ReadWrite);
        static void Main(string[] args)
        {
            string clave;
            do
            {
                Console.WriteLine("Ingrese su contraseña: ");
                clave = Console.ReadLine();
            } while (clave.Length < 7 || clave.Length > 20);

            Console.WriteLine("\nEncriptacion: " + encript(clave));

            Console.WriteLine("\nClave: " + desencript(clave));

            StreamWriter archivo = new StreamWriter(fs);
            archivo.WriteLine(encript(clave));
            archivo.Close();
            fs.Close();
            Console.WriteLine("La clave ha sido encriptada con exito.");
            Console.WriteLine("Presione <Enter> para continuar...");
            Console.ReadKey();
        }
        

        #region validacion
        static int validaciones(string mensaje, int menor, int mayor)
        {
            bool condicion;
            int op;
            do
            {
                Console.WriteLine(mensaje);
                condicion = int.TryParse(Console.ReadLine(), out op);
            } while (condicion == false || op < menor || op > mayor);
            return op;
        }
        #endregion
        
        #region encriptacion

        public static string encript(string clave)
        {
            string encriptado = string.Empty;
            Byte[] encriptar = System.Text.Encoding.Unicode.GetBytes(clave);
            encriptado = Convert.ToBase64String(encriptar);
            fs.Close();
            return encriptado;
        }
        #endregion
        
        #region desencriptacion
        public static string desencript(string clave)
        {
            string desencriptado = string.Empty;
            Byte[] desencriptar = Convert.FromBase64String(encript(clave));
            desencriptado = System.Text.Encoding.Unicode.GetString(desencriptar);
            fs.Close();
            return desencriptado;
        }
        #endregion
    }
}
