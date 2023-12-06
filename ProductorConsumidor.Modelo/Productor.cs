using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductorConsumidor.Modelo
{
    public class Productor
    {
        private IBuffer _ubicacionCompartida;
        private Random _tiempoInactividad;
        public Productor(IBuffer ubicacionCompartida, Random tiempoInactividad)
        {
            _ubicacionCompartida = ubicacionCompartida;
            _tiempoInactividad = tiempoInactividad;
        }

        public void Producir()
        {
            for (int i = 1; i <= 10; i++)
            {
                Thread.Sleep(_tiempoInactividad.Next(1, 1001));
                _ubicacionCompartida.Buffer = i;
            }
            Console.WriteLine("{0} terminó de producir.\nTerminando {0}.",
            Thread.CurrentThread.Name);
        }
    }
}
