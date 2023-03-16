using Practica3.EF.Entities;
using Practica3.EF.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica3.EF.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ShipperLogic shipperLogic = new ShipperLogic();

            while (true)
            {
                Console.WriteLine("Menu de Programa");
                Console.WriteLine("1. Consultar Shippers y Suppliers");
                Console.WriteLine("2. Añadir Shipper");
                Console.WriteLine("3. Eliminar Shipper");
                Console.WriteLine("4. Actualizar Shipper");
                Console.WriteLine("5. Salir");
                Console.Write("Ingrese su opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.WriteLine();
                        Console.WriteLine("Lista de Shippers");

                        foreach (var ship in shipperLogic.GetAll())
                        {
                            Console.WriteLine($"{ship.ShipperID} - {ship.CompanyName}");
                        }
                        Console.WriteLine();

                        Console.WriteLine("Lista de Suppliers");

                        SupplierLogic supplierLogic = new SupplierLogic();
                        foreach (var supp in supplierLogic.GetAll())
                        {
                            Console.WriteLine($"{supp.SupplierID} - {supp.CompanyName}");
                        }
                        break;

                    case "2":
                        Console.Write("Ingrese el nombre del Shipper: ");
                        string nombre = Console.ReadLine();

                        shipperLogic.Add(new Shippers { CompanyName = nombre });
                        break;

                    case "3":
                        Console.WriteLine();
                        Console.WriteLine("Lista de Shippers");

                        foreach (var ship in shipperLogic.GetAll())
                        {
                            Console.WriteLine($"{ship.ShipperID} - {ship.CompanyName}");
                        }
                        Console.WriteLine();
                        int num;
                        Console.Write("Ingrese el ID del Shipper que desea eliminar: ");
                        string ent = Console.ReadLine();
                        while (!int.TryParse(ent, out num))
                        {
                            Console.WriteLine("La entrada no es un número válido. Intente de nuevo.");
                            Console.Write("Ingrese un número entero: ");
                            ent = Console.ReadLine();
                        }

                        shipperLogic.Delete(num);
                        Console.WriteLine();
                        Console.WriteLine("Lista de Shippers");

                        foreach (var ship in shipperLogic.GetAll())
                        {
                            Console.WriteLine($"{ship.ShipperID} - {ship.CompanyName}");
                        }


                        break;

                    case "4":
                        Console.WriteLine();
                        Console.WriteLine("Lista de Shippers");

                        foreach (var ship in shipperLogic.GetAll())
                        {
                            Console.WriteLine($"{ship.ShipperID} - {ship.CompanyName}");
                        }
                        Console.WriteLine();
                        int numero;
                        Console.Write("Ingrese el ID del Shipper que desea actualizar: ");
                        string entrada = Console.ReadLine();
                        while (!int.TryParse(entrada, out numero))
                        {
                            Console.WriteLine("La entrada no es un número válido. Intente de nuevo.");
                            Console.Write("Ingrese un número entero: ");
                            entrada = Console.ReadLine();
                        }

                        Console.WriteLine("Ingrese el nombre del Shipper: ");
                        string nom = Console.ReadLine();
                        shipperLogic.Update(new Shippers { ShipperID = numero, CompanyName = nom });

                        Console.WriteLine();
                        Console.WriteLine("Lista de Shippers");

                        foreach (var ship in shipperLogic.GetAll())
                        {
                            Console.WriteLine($"{ship.ShipperID} - {ship.CompanyName}");
                        }

                        break;

                    case "5":
                        Console.WriteLine("Saliendo del programa.");
                        return;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }


                Console.ReadLine();
            }
        }
    }
}
