using ProductorConsumidor.Modelo;

namespace ProductorConsumidor.ConSincronizacion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BufferImpl recursoCompartido = new BufferImpl();
            Random generador = new Random();
            Console.WriteLine("{0, -40}{1,-9}{2}\n", "Operación", "Buffer", "Conteo ocupado");
            recursoCompartido.MostrarEstado("Estado inicial");
            Productor productor = new Productor(recursoCompartido, generador);
            Consumidor consumidor = new Consumidor(recursoCompartido, generador);
            Thread hiloProductor = new Thread(new ThreadStart(productor.Producir));
            hiloProductor.Name = "Productor";
            Thread hiloConsumidor = new Thread(new ThreadStart(consumidor.Consumir));
            hiloConsumidor.Name = "Consumidor";
            hiloProductor.Start();
            hiloConsumidor.Start();
        }
    }
}