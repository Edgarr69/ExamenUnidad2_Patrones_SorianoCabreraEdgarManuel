using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenU2
{
    class Program
    {
        static void Main(string[] args)
        {
            var centro = CentroControlMaritimo.Instancia;
            centro.EnviarMensaje("Iniciando control de flotas...");

            //Se crea un grupo de 3 barcos disponibles
            PoolBarcos pool = new PoolBarcos(3);

            Barco b1 = pool.ObtenerBarco();
            Barco b2 = pool.ObtenerBarco();
            Barco b3 = pool.ObtenerBarco();

            b1.Navegar("Ruta Tijuana - Ensenada");
            b2.Navegar("Ruta Mazatlan - La Paz");
            b3.Navegar("Ruta Veracruz - Cozumel");

            centro.EnviarMensaje("Monitoreando rutas maritimas...");

            // Liberar un barco y reutilizarlo
            pool.LiberarBarco(b2);
            Barco b4 = pool.ObtenerBarco();
            b4.Navegar("Ruta Manzanillo - Acapulco");

            centro.EnviarMensaje("Fin de simulacion marítima.");
            Console.ReadLine();
        }
    }
}

