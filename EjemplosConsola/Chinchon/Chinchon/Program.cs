using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinchon
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Cuantos jugadores quieres? [1-4]");
            byte jugadores=byte.Parse( Console.ReadLine());
            Juego juego = new Juego(jugadores);
            
            Console.WriteLine("Fin del programa");
            Console.ReadKey();
        }
    }
}
