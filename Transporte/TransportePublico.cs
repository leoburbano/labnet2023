using System;

namespace Transporte
{
    abstract class TransportePublico
    {
        private int pasajeros { get; set; }

        public TransportePublico(int pasajeros)
        {
            this.pasajeros = pasajeros;
        }


        public void Avanzar()
        {
            Console.WriteLine($"Estoy avanzando con {pasajeros} pasajeros");
        }

        public void Detenerse()
        {
            Console.WriteLine($"Estoy deteniendome con {pasajeros} pasajeros");
        }

        public abstract void Tipo();
    }

}
