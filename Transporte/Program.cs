using System;
using System.Collections.Generic;

namespace Transporte
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<TransportePublico> transportes = new List<TransportePublico>();

            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"Agregar pasajeros para el Omnibus # {i}. Número maximo 25");

                transportes.Add(new Omnibus(Int32.Parse(Console.ReadLine()), i));
            }

            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"Agregar pasajeros para el taxi # {i}. . Número maximo 5");

                transportes.Add(new Taxi(Int32.Parse(Console.ReadLine()), i));


            }

            foreach (var item in transportes)
            {
                item.Tipo();
                item.Avanzar();
            }
            Console.ReadKey();
        }
    }
}
