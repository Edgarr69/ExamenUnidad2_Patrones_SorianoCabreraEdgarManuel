using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenU2
{
    public class CentroControlMaritimo
    {
        // Variable estática que guarda la única instancia del centro
        private static CentroControlMaritimo _instancia;
        // Objeto para evitar conflictos si varios hilos acceden al mismo tiempo
        private static readonly object _lock = new object();

        public string NombreCentro { get; private set; }

        private CentroControlMaritimo()
        {
            NombreCentro = "Centro Global de Control Marítimo";
        }

        public static CentroControlMaritimo Instancia
        {
            get
            {
                lock (_lock) 
                {
                    if (_instancia == null)
                        _instancia = new CentroControlMaritimo();
                    return _instancia;
                }
            }
        }
        public void EnviarMensaje(string mensaje)
        {
            Console.WriteLine($"\nCENTRO DE CONTROL: {mensaje}");
        }
    }
}

