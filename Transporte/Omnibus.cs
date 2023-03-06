using System;

namespace Transporte
{
    class Omnibus : TransportePublico
    {
        private int numero { get; set; }

        public Omnibus(int pasajeros, int numero) : base(pasajeros)
        {
            this.numero = numero;

        }

        public override void Tipo()
        {
            Console.WriteLine($"Vehiculo Omnibus # {numero}");
        }
    }
}
