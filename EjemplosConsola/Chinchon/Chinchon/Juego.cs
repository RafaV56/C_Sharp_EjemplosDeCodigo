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
            //Creo una baraja
            Baraja = new Baraja(13);
            //Crea una lista para ver las cartas sobre la mesa
            List<Carta> cartasEnLaMesa = new List<Carta>();
            //La Barajo antes de repartir
            Baraja.Barajar();
            //Por cada jugador
            for (int i = 0; i < MAXIMO_JUGADORES; i++)
            {
                //por cada jugador se reparte su máximo de cartas
                for (int sub = 0; sub < Jugador.MAXIMO_CARTAS; sub++)
                {
                    jugadores.ElementAt(i).Cartas.Add(Baraja.DarCarta());
                }
               
            }
            //Ahora los jugadores ya tiene las cartas 7 y sobran 24 en la baraja
            //Ver los jugadores principales
            cartasEnLaMesa.Add(Baraja.DarCarta());//Doy la primera carta del juego
            while (true)//cambiar
            {

                foreach (var item in jugadores)
                {
                    if (!item.JugadorMaquina)
                    {
                        Console.WriteLine(item.ToString());
                        item.VerCartas();
                        Console.WriteLine("\nLa carta en la mesa es: " + cartasEnLaMesa.ElementAt(cartasEnLaMesa.Count()-1));
                        Console.WriteLine("¿Tomar carta? [ (1:SI) - (2:NO)[ Robar de la baraja ]");
                        byte opcion = byte.Parse(Console.ReadLine());
                        if (opcion == 1)
                        {
                            //Tomo la carta de la mesa y la cambia por otra, la carta cambiada queda de ultima en la lista de cartas en la mesa
                            Cambiar(cartasEnLaMesa, item.Cartas);
                        }
                        else
                        {
                            cartasEnLaMesa.Add(Baraja.DarCarta());//Doy nueva carta del juego
                            Console.WriteLine("\nLa carta al robar es: " + cartasEnLaMesa.ElementAt(cartasEnLaMesa.Count() - 1));
                            Console.WriteLine("¿Tomar carta? [ (1:SI) - (2:NO)");
                            byte opcion2 = byte.Parse(Console.ReadLine());
                            if (opcion2 == 1)
                            {
                                //Tomo la carta de la mesa y la cambia por otra, la carta cambiada queda de ultima en la lista de cartas en la mesa
                                Cambiar(cartasEnLaMesa, item.Cartas);
                            }

                        }
                        Console.Clear();
                        }
                }

            }

            //Ver los jugadores y sus cartas
            //foreach (var item in jugadores)
            //{
            //    Console.WriteLine(item.ToString());
            //    item.VerCartas();
            //}
            //Console.WriteLine(Baraja.Cartas.Count());
        }
 
        /// <summary>
        /// Cambia una carta de la baraja del jugador por otra la última que llega de la mesa
        /// </summary>
        /// <param name="cartasEnLaMesa"></param>
        /// <param name="cartas"></param>
        private void Cambiar(List<Carta> cartasEnLaMesa, List<Carta> cartas)
        {
            Console.WriteLine("Escriba el número de la carta a cambiar [ 1-7 ]");
            byte opcion = byte.Parse(Console.ReadLine());
            Carta nueva = cartasEnLaMesa.ElementAt(cartasEnLaMesa.Count() - 1);
            Carta vieja = cartas.ElementAt(opcion - 1);
            cartas.Remove(vieja);
            cartasEnLaMesa.Remove(nueva);
            cartas.Add(nueva);
            cartasEnLaMesa.Add(vieja);
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
