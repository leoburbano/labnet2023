using Practica3.EF.Data;
using Practica3.EF.Entities;
using Practica3.EF.Logic;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Practica3.EF.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var db = new NorthwindContext();

            while (true)
            {
                Console.WriteLine("Menu de Programa");
                Console.WriteLine("1. Query para devolver objeto customer");
                Console.WriteLine("2. Query para devolver todos los productos sin stock");
                Console.WriteLine("3. Query para devolver todos los productos que tienen stock y que cuestan más de 3 por unidad");
                Console.WriteLine("4. Query para devolver todos los customers de la Región WA");
                Console.WriteLine("5. Query para devolver el primer elemento o nulo de una lista de productos donde el ID de producto sea igual a 789");
                Console.WriteLine("6. Query para devolver los nombre de los Customers. Mostrarlos en Mayuscula y en Minuscula.");
                Console.WriteLine("7. Query para devolver Join entre Customers y Orders donde los customers sean de la Región WA y la fecha de orden sea mayor a 1/1/1997.");
                Console.WriteLine("8. Salir");
                Console.Write("Ingrese su opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.WriteLine();
                        Console.WriteLine("Lista de Customers");

                        var query = from customers in db.Customers
                                    select customers;



                        foreach (var item in query)
                        {
                            Console.WriteLine($"Company Name: {item.CompanyName} -  Contact Name: {item.ContactName}");
                        }
                        Console.WriteLine();

                        break;

                    case "2":
                        Console.WriteLine();
                        Console.WriteLine("Lista de Productos sin stock");

                        var query2 = from products in db.Products
                                     where products.UnitsInStock == 0 
                                    select products;



                        foreach (var item in query2)
                        {
                            Console.WriteLine($"Product Id: {item.ProductID} -  Product Name: {item.ProductName} - Units: {item.UnitsInStock}");
                        }
                        Console.WriteLine();
                        break;

                    case "3":
                        Console.WriteLine();
                        Console.WriteLine("Lista de Productos con stock y precio unitario de mas de 3");

                        var query3 = from products in db.Products
                                     where (products.UnitsInStock != 0 && products.UnitPrice > 3) 
                                     select products;



                        foreach (var item in query3)
                        {
                            Console.WriteLine($"Product Id: {item.ProductID} -  Product Name: {item.ProductName} - Units: {item.UnitsInStock} - Unit Price: {item.UnitPrice}" );
                        }
                        Console.WriteLine();
                        break;

                    case "4":
                        Console.WriteLine();
                        Console.WriteLine("Lista de Customers con Region WA");

                        var query4 = from customers in db.Customers
                                     where customers.Region == "WA"
                                    select customers;



                        foreach (var item in query4)
                        {
                            Console.WriteLine($"Company Name: {item.CompanyName} -  Contact Name: {item.ContactName} - Region: {item.Region}");
                        }
                        Console.WriteLine();

                        break;
                    case "5":
                        Console.WriteLine();
                        Console.WriteLine("Query para devolver el primer elemento o nulo de una lista de productos donde el ID de producto sea igual a 789");

                        var query5 = db.Products.FirstOrDefault(p => p.ProductID == 789);
                        
                        if(query5 != null)
                        {

                        Console.WriteLine(query5);
                        } else
                        {
                            Console.WriteLine("El resultado es null");
                        }
                        
                        Console.WriteLine();

                        break;
                    case "6":
                        Console.WriteLine();

                        Console.WriteLine();
                        Console.WriteLine("Lista de Customers");

                        var query6 = from customers in db.Customers
                                    select customers;


                        Console.WriteLine("Lista de Customers en mayuscula");

                        foreach (var item in query6)
                        {
                            Console.WriteLine($"Contact Name: {item.ContactName.ToUpper()}");
                        }
                        Console.WriteLine();

                        Console.WriteLine("Lista de Customers en minuscula");

                        foreach (var item in query6)
                        {
                            Console.WriteLine($"Contact Name: {item.ContactName.ToLower()}");
                        }
                        Console.WriteLine();

                        break;

                    case "7":
                        Console.WriteLine("Query para devolver Join entre Customers y Orders donde los customers sean de la Región WA y la fecha de orden sea mayor a 1/1/1997");
                        var query7  = db.Customers
                            .Where(c => c.Region == "WA")
                            .Join(db.Orders,
                            customer => customer.CustomerID,
                            order => order.CustomerID,
                            (customer, order) => new { Customer = customer, Order = order })
                            .Where(co => co.Order.OrderDate > new DateTime(1997, 1, 1))
                            .Select(co => new { co.Customer.CompanyName, co.Order.OrderDate });

                        foreach (var item in query7)
                        {
                            Console.WriteLine($"Customer: {item.CompanyName} - Order Date: {item.OrderDate}");
                        }
                        Console.WriteLine();


                        break;

                    case "8":
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
