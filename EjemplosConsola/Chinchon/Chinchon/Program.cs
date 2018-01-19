using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinchon
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Cuantos jugadores quieres? [1-4]");
        //    int jugadores = 1;
        //    try
        //    {
        //        jugadores = int.Parse(Console.ReadLine());
        //    }
        //    catch (Exception)
        //    {
        //        jugadores = 1;
        //    }
        //    Console.WriteLine("Cuantos jugadores principales? [1-4]");
        //    int jugadoresPrincipales = 1;
        //    try
        //    {
        //        jugadoresPrincipales = int.Parse(Console.ReadLine());
        //    }
        //    catch (Exception)
        //    {
        //        jugadoresPrincipales = 1;
        //    }
        //    Juego juego = new Juego(jugadoresPrincipales, jugadores);

        //    Console.WriteLine("Fin del programa");
        //    Console.ReadKey();
        //}


        //metodo de prueba
        static void Main(string[] args)
        {

            Jugador juga = new Jugador("Prueba", false);
            juga.AgregarCarta(new Carta(6, Palo.CORAZONES));
            juga.AgregarCarta(new Carta(6, Palo.PICAS));
            juga.AgregarCarta(new Carta(6, Palo.TREBOLES));
            juga.AgregarCarta(new Carta(6, Palo.DIAMANTES));
            juga.AgregarCarta(new Carta(1, Palo.CORAZONES));
            juga.AgregarCarta(new Carta(7, Palo.CORAZONES));
            juga.AgregarCarta(new Carta(5, Palo.CORAZONES));

            juga.SumarPuntos();

            juga.SeisCartas();
        }

    }
}
