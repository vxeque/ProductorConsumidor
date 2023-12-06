using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductorConsumidor.Modelo;

namespace ProductorConsumidor.SinSincronizacion
{
    class BufferImpl : IBuffer
    {
        private int _buffer = -1;
        public int Buffer
        {
            get
            {
                Console.WriteLine("{0} leyó el valor {1}",
                Thread.CurrentThread.Name, _buffer);
                return _buffer;
            }
            set
            {
                _buffer = value;
                Console.WriteLine("{0} escribió el valor {1}",
                Thread.CurrentThread.Name, value);
            }
        }
    }
}
