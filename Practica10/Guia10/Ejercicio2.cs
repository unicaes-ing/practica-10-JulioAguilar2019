using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Guia10
{
    class Ejercicio2
    {
        public static string[] pais;
        static void Main(string[] args)
        {
            int op, max;
            do
            {
                Console.WriteLine(" 1 - Agregar Pais.");
            Console.WriteLine(" 2 - Mostrar Pais.");
            Console.WriteLine(" 3 - Buscar Pais.");
            Console.WriteLine(" 4 - Salir.");
            op = validaciones("Seleccione una opción: ", 1, 4);
            switch (op)
            {
                case 1:
                    Console.Clear();
                    StreamWriter archivo = new StreamWriter(@"C:\Users\Usuario\arreglo.txt", true);
                    Console.WriteLine("¿Cuantos paises desea agregar?");
                    max = validaciones("El máximo de paises que puede agregar son 10", 1, 10);
                    pais = new string[max];
                    for (int npaises = 0; npaises < pais.Length; npaises++)
                    {
                        Console.WriteLine($"Pais {npaises + 1}");
                        pais[npaises] = Console.ReadLine();
                    }
                    string txt = string.Join(",", pais);
                    archivo.Write(txt);
                    archivo.Close();
                    Console.WriteLine("Presione <Enter> para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 2:
                    Console.Clear();
                    StreamReader txt2 = new StreamReader(@"C:\Users\Usuario\arreglo.txt");
                    string text;
                    text = txt2.ReadToEnd();
                    //Console.WriteLine(text);
                    pais = text.Split(',');
                    txt2.Close();
                    int i = 1;
                    Console.WriteLine("Lista de paises almacenados: \n");
                    foreach (string item in pais)
                    {
                        Console.WriteLine($"Nombre {i}: {item}");
                        i++;
                    }
                    Console.WriteLine("Presione <Enter> para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 3:
                    Console.Clear();
                    StreamReader txt3 = new StreamReader(@"C:\Users\Usuario\arreglo.txt");
                    string linea;
                    string buscar;
                    Console.WriteLine("Ingrese el nombre del pais que desea buscar:");
                    buscar = Console.ReadLine();
                    i = 1;
                    do
                    {
                        linea = txt3.ReadLine();
                        if (linea != null)
                        {
                            foreach (string item in pais)
                            {
                                if (item.Equals(buscar))
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine($"Nombre {i}: {item}");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    Console.WriteLine($"Nombre {i}: {item}");
                                }
                                i++;
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
