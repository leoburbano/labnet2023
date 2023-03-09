using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2
{
    public class Operaciones
    {
        public int DividirCero(int num)
        {
            try
            {
                return 20 / num;
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Error: {ex.Message} ");
                return 0;
            }
            finally
            {
                Console.WriteLine("La operacion termino");
            }
        }

        public int Dividir(int dividendo, int divisor)
        {
            try
            {
                return dividendo / divisor;

            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Solo Chuck Norris divide por cero! " + e.Message);
                return 0;
            }
            catch (FormatException)
            {
                Console.WriteLine("¡Por favor solo ingresar numeros!");
                return 0;
            }
            finally
            {
                Console.WriteLine("La operacion termino!!!");

            }
        }

        public string Nombre(string nombre)
        {
            if(nombre == "Leandro") {
                return "Leandro";
            }
            else
            {
                throw new ExcepcionPersonalizada();
            }
        }
    }
} 
