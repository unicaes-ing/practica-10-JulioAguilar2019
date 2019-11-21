using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Guia10
{
    class ejercicio1
    {
        static void Main(string[] args)
        {
            int op;
            do
            {
                Console.WriteLine(" 1 - Agregar Pais.");
                Console.WriteLine(" 2 - Mostrar Paises.");
                Console.WriteLine(" 3 - Buscar Pais.");
                Console.WriteLine(" 4 - Salir.");
                op = validaciones("Seleccione una opción: ", 1, 4);
                switch (op)
                {
                    case 1:
                        Console.Clear();
                        StreamWriter archivo = new StreamWriter(@"C:\Users\Usuario\paises.txt", true);
                        Console.WriteLine("Ingrese el pais desea agregar: ");
                        archivo.WriteLine(Console.ReadLine());
                        archivo.Close();
                        Console.WriteLine("Presione <Enter> para continuar...");
                        Console.ReadKey();

                        break;
                    case 2:
                        Console.Clear();
                        StreamReader txt = new StreamReader(@"C:\Users\Usuario\paises.txt");
                        string text;
                        text = txt.ReadToEnd();
                        Console.WriteLine(text);
                        txt.Close();
                        Console.WriteLine("Presione <Enter> para continuar...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 3:
                        Console.Clear();
                        StreamReader txt1 = new StreamReader(@"C:\Users\Usuario\paises.txt");
                        string linea;
                        string buscar;
                        Console.WriteLine("Ingrese el pais que desea buscar:");
                        buscar = Console.ReadLine();
                        do
                        {
                            linea = txt1.ReadLine();
                            if (linea != null)
                            {
                                if (linea.Equals(buscar))
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine(linea);
                                    Console.ResetColor();
                                }
                                else
                                {
                                    Console.WriteLine(linea);
                                }
                            }
                        } while (linea != null);
                        Console.WriteLine("Presione <Enter> para continuar...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 4:
                        Console.Clear();
                        Environment.Exit(4);
                        break;
                }
            } while (op != 4);           
           
        }
        #region
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
    }
}
