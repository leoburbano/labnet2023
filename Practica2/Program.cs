using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Operaciones operaciones= new Operaciones();
            Console.WriteLine("Ingresa un número:");
            int numero = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(operaciones.DividirCero(numero));


            Console.WriteLine("Ingresar dividendo");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingresar divisor");
            int num2 = Convert.ToInt32(Console.ReadLine());
            int resultado = operaciones.Dividir(num1, num2);
            Console.WriteLine("La división es: " + resultado);

            Console.WriteLine("Ingresa tu nombre: ");
            string nom = Console.ReadLine();  

            Console.WriteLine(operaciones.Nombre(nom));

            Console.ReadKey();
        }
    }
}
