using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductorConsumidor.Modelo
{
    public class Consumidor
    {
        private IBuffer _ubicacionCompartida;
        private Random _tiempoInactividad;
        public Consumidor(IBuffer ubicacionCompartida, Random tiempoInactividad)
        {
            _ubicacionCompartida = ubicacionCompartida;
            _tiempoInactividad = tiempoInactividad;
        }

        public void Consumir()
        {
            int suma = 0;
            for (int i = 1; i <= 10; i++)
            {
                Thread.Sleep(_tiempoInactividad.Next(1, 2001));
                suma += _ubicacionCompartida.Buffer;
            }
            Console.WriteLine("{0} leyó y sumó valores para un total de: {1}",
            Thread.CurrentThread.Name, suma);
        }
    }
}