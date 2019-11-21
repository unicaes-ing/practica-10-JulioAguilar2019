using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Guia10
{
    class Ejercicio4
    {
        public static FileStream fs = new FileStream(@"C:\Users\Usuario\encriptacion.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);

        static void Main(string[] args)
        {
            int n = 0;
            string compaclave;
            StreamReader archivo = new StreamReader(fs);
            string clave = archivo.ReadLine();
            string comp = desencript(clave);
            archivo.Close();
            do
            {
                Console.Write("Ingrese la contraseña: ");
                compaclave = Console.ReadLine();
                Console.WriteLine("");
                Console.WriteLine(comp);
                n++;
            } while (n != 3 && clave.Equals(desencript(compaclave)));

            if (clave.Equals(compaclave))
            {
                Console.WriteLine("Contraseña correcta");
            }
            else
            {
                if (clave != compaclave)
                {
                    Console.WriteLine("Contraseña correcta");
                }
                else
                {
                    if (n == 3)
                    {
                        Console.WriteLine("Acceso bloqueado por abuso de intentos");
                    }
                }

            }
            Console.WriteLine("Presione <Enter> para continuar...");
            Console.ReadKey();
        }
        public static string encript(string clave)
        {
            string encriptado = string.Empty;
            Byte[] encriptar = System.Text.Encoding.Unicode.GetBytes(clave);
            encriptado = Convert.ToBase64String(encriptar);
            return encriptado;
        }
        public static string desencript(string clave)
        {
            string desencriptado = string.Empty;
            Byte[] desencriptar = Convert.FromBase64String(encript(clave));
            desencriptado = System.Text.Encoding.Unicode.GetString(desencriptar);
            return desencriptado;
        }
    }
}