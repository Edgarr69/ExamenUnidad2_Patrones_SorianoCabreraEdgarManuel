using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenU2
{
    public class Barco
    {
        public int Id { get; set; }
        public bool EnUso { get; set; }

        public void Navegar(string ruta)
        {
            Console.WriteLine($"Barco #{Id} navegando por la ruta: {ruta}");
        }
    }

}
