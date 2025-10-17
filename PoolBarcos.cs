using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenU2
{
    public class PoolBarcos
    {
        private readonly List<Barco> _barcosDisponibles = new List<Barco>();
        private readonly List<Barco> _barcosEnUso = new List<Barco>();
        private readonly object _lock = new object();

        public PoolBarcos(int cantidadInicial)
        {
            for (int i = 1; i <= cantidadInicial; i++)
                _barcosDisponibles.Add(new Barco { Id = i, EnUso = false });
        }

        public Barco ObtenerBarco()
        {
            lock (_lock)
            {
                if (_barcosDisponibles.Count > 0)
                {
                    Barco barco = _barcosDisponibles[0];
                    _barcosDisponibles.RemoveAt(0);
                    barco.EnUso = true;
                    _barcosEnUso.Add(barco);
                    Console.WriteLine($"Se asignó el Barco #{barco.Id}");
                    return barco;
                }
                else
                {
                    Console.WriteLine("No hay barcos disponibles, espere...");
                    return null;
                }
            }
        }

        public void LiberarBarco(Barco barco)
        {
            lock (_lock)
            {
                barco.EnUso = false;
                _barcosEnUso.Remove(barco);
                _barcosDisponibles.Add(barco);
                Console.WriteLine($"El Barco #{barco.Id} regresó al puerto y esta disponible.");
            }
        }
    }
}
