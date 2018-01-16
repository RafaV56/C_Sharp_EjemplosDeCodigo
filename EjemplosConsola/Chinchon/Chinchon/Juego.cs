using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinchon
{
    class Juego
    {
        string[] nombre;
        int opcion;
        public const byte MAXIMO_JUGADORES = 4;
        List<Jugador> jugadores;
        public Baraja Baraja { get; set; }

        public Juego(byte JugadoresPrincipales)
        {
            nombre =new string[]{ "Jazmin", "Lolo", "Jero" };
            jugadores = new List<Jugador>();
            if (JugadoresPrincipales>4)
            {
                JugadoresPrincipales = 4;
            }
            else if (JugadoresPrincipales < 1)
            {
                JugadoresPrincipales = 1;
            }
            for (int i = 0; i < JugadoresPrincipales; i++)
            {
                CrearJugadorPrincipal();
            }
            for (int i = jugadores.Count(); i < MAXIMO_JUGADORES; i++)
            {
                CrearJugadorMaquina();
            }
            Jugar();
        }

        /// <summary>
        /// Crea una partida completa
        /// </summary>
        private void Jugar()
        {
            Baraja = new Baraja(13);
            Baraja.Barajar();
            for (int i = 0; i < MAXIMO_JUGADORES; i++)
            {
                for (int sub = 0; sub < Jugador.MAXIMO_CARTAS; sub++)
                {
                    jugadores.ElementAt(i).Cartas.Add(Baraja.DarCarta());
                }
               
            }
            //Seguir aqui. los jugadores ya tiene las cartas. 7 y sobran 20 en la baraja
            foreach (var item in jugadores)
            {
                Console.WriteLine(item.ToString());
                item.VerCartas();
            }
            Console.WriteLine(Baraja.Cartas.Count());
        }

        private void CrearBaraja()
        {
            Baraja = new Baraja(13); ;
        }

        /// <summary>
        /// Crear un jugador Principal
        /// </summary>
        public void CrearJugadorPrincipal()
        {
            Console.WriteLine("Dime el nombre del jugador Principal");
            string nombre = Console.ReadLine();
            Jugador juga = new Jugador(nombre,false);
            if (jugadores.Count() <=MAXIMO_JUGADORES)
            {
                jugadores.Add(juga); 
            }
            else
            {
                Console.WriteLine("No se puede añadir  el jugador, Máximo 4 jugadores");
            }

        }

        public void CrearJugadorMaquina()
        {
           
            Jugador juga = new Jugador(nombre[opcion++], true);
            if (jugadores.Count() <= MAXIMO_JUGADORES)
            {
                jugadores.Add(juga);
            }
            else
            {
                Console.WriteLine("No se puede añadir  el jugador, Máximo 4 jugadores");
            }
        }

        public void ListarJugadores()
        {
            foreach (var item in jugadores)
            {
                Console.WriteLine(item.ToString());
            }
        }

    }
}
