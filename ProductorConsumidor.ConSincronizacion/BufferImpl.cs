using ProductorConsumidor.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductorConsumidor.ConSincronizacion
{
    internal class BufferImpl : IBuffer
    {
        private int _buffer = -1;
        private int _conteoBufferOcupado = 0;
        public int Buffer
        {
            get
            {
                Monitor.Enter(this);
                if (_conteoBufferOcupado == 0)
                {
                    Console.WriteLine("{0} está intentando leer.",
                    Thread.CurrentThread.Name);
                    MostrarEstado($"Buffer vacío. {Thread.CurrentThread.Name} en espera.");
                    Monitor.Wait(this);
                }
                _conteoBufferOcupado--;
                MostrarEstado($"{Thread.CurrentThread.Name} lee {_buffer}.");
                Monitor.Pulse(this);
                int copiaBuffer = _buffer;
                Monitor.Exit(this);
                return copiaBuffer;
            }
            set
            {
                Monitor.Enter(this);
                if (_conteoBufferOcupado == 1)
                {
                    Console.WriteLine("{0} está intentando escribir.",
                    Thread.CurrentThread.Name);
                    MostrarEstado($"Buffer lleno. {Thread.CurrentThread.Name} en espera.");
                    Monitor.Wait(this);
                }
                _buffer = value;
                _conteoBufferOcupado++;
                MostrarEstado($"{Thread.CurrentThread.Name} escribe {_buffer}");
                Monitor.Pulse(this);
                Monitor.Exit(this);
            }
        }
        public void MostrarEstado(string operacion)
        {
            Console.WriteLine("{0, -40}{1,-9}{2}",
            operacion, _buffer, _conteoBufferOcupado);
        }
    }
}
