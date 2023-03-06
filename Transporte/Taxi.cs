using System;


namespace Transporte
{
    internal class Taxi: TransportePublico
    {
        private int numero { get; set; }

        public Taxi(int pasajeros, int numero) : base(pasajeros)
        {
            this.numero = numero;

        }

        public override void Tipo()
        {
            Console.WriteLine($"Vehiculo Taxi # {numero}");
        }
    }
}
