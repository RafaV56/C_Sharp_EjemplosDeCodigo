using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinchon
{
    class Juego
    {
        /// <summary>
        /// Nombres de los jugadores máquina
        /// </summary>
        string[] nombre;

        int opcion;
        public const int MAXIMO_JUGADORES = 4;
        public int totalJugadores;
        List<Jugador> jugadores;
        public Baraja Baraja { get; set; }

        public Juego(int JugadoresPrincipales, int totalJugadores)
        {
            if (totalJugadores>4)
            {
                this.totalJugadores = 4;
            }
            else if (totalJugadores < 1)
            {
                this.totalJugadores = 1;
            }
            else
            {
                this.totalJugadores = totalJugadores;
            }

            if (JugadoresPrincipales > 4)
            {
                JugadoresPrincipales = 4;
            }
            else if (JugadoresPrincipales < 1)
            {
                JugadoresPrincipales = 1;
            }
           

            if (JugadoresPrincipales>totalJugadores)
            {
                JugadoresPrincipales = this.totalJugadores;
            }

            nombre =new string[]{ "Jazmin", "Lolo", "Jero" };
            jugadores = new List<Jugador>();
                   
            for (int i = 0; i < JugadoresPrincipales; i++)
            {
                CrearJugadorPrincipal();
            }
            for (int i = jugadores.Count(); i < totalJugadores; i++)
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
            //Se acaba el juego si se asigna true, hay ganador, solo un jugador tiene menos de jugador.MAXIMOPUNTAJE
            bool final = false;
            while (!final)
            {
                Console.WriteLine("\t*** Empieza el nuevo juego ***");
                //Creo una baraja
                Baraja = new Baraja(13);
                //Crea una lista para ver las cartas sobre la mesa
                List<Carta> cartasEnLaMesa = new List<Carta>();
                //La Barajo antes de repartir
                Baraja.Barajar();
                //Por cada jugador
                //Borramos sus cartas anteriores
                foreach (var item in jugadores)
                {
                    item.Cartas = new List<Carta>();
                }
                //Y damos sus cartas
                for (int i = 0; i < jugadores.Count(); i++)
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
                                                      //Cuando termido pase a true alguine tiene juego
                bool terminado = false;
                while (!terminado)
                {

                    foreach (var item in jugadores)
                    {
                        if (!item.JugadorMaquina)
                        {
                            Console.WriteLine(item.ToString());
                            item.VerCartas();
                            Console.WriteLine("Puntos sumados en la mano: [" + item.PuntosTotalesMano() + "]");

                            Console.WriteLine("\nLa carta en la mesa es: " + cartasEnLaMesa.ElementAt(cartasEnLaMesa.Count() - 1));
                            byte opcion;
                            do
                            {
                                Console.WriteLine("¿Tomar carta? [ (1:SI) - (2:NO)[ Robar de la baraja ] -(3)Ordenar por palo");
                                try
                                {
                                    opcion = byte.Parse(Console.ReadLine());
                                }
                                catch (Exception)
                                {

                                    opcion = 3;
                                }
                                if (opcion == 3)
                                {
                                    item.Cartas.Sort();
                                    item.VerCartas();
                                    Console.WriteLine("Puntos sumados en la mano: [" + item.PuntosTotalesMano() + "]");
                                }
                            } while (!(opcion == 1 || opcion == 2));
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
                                byte opcion2 = 2;
                                try
                                {
                                     opcion2 = byte.Parse(Console.ReadLine());
                                }
                                catch (Exception)
                                {
                                    opcion2 = 2;
                                }
                                if (opcion2 == 1)
                                {
                                    //Tomo la carta de la mesa y la cambia por otra, la carta cambiada queda de ultima en la lista de cartas en la mesa
                                    Cambiar(cartasEnLaMesa, item.Cartas);
                                }

                            }
                            if (item.PuntosTotalesMano() <= 5)
                            {
                                if ((item.Puntos + item.PuntosTotalesMano()) < Jugador.MAXIMO_PUNTAJE && item.SeisCartas())
                                {
                                    item.VerCartas();
                                    Console.WriteLine("Puntos sumados en la mano: [" + item.PuntosTotalesMano() + "]");
                                    Console.WriteLine("\nTienes juego para bajarte, ¿Quieres terminar? 1)Si 2)No");
                                    int bajarse = int.Parse(Console.ReadLine());
                                    if (bajarse == 1)
                                    {
                                        terminado = true;
                                    }
                                }
                            }
                            Console.Clear();
                        }
                        //Se se termina el juego no se pregunta a más jugadores
                        if (terminado)
                        {
                            break;
                        }
                    }

                }
                Console.WriteLine("\n\t*** Terminado el juego.. ***");
                //Maximo puntaje de la lista de jugadores
                int maxPuntos = 0;
                //Sumamos los puntos
                foreach (var item in jugadores)
                {
                    item.SumarPuntos();
                    if (item.Puntos<=Jugador.MAXIMO_PUNTAJE && item.Vida && maxPuntos< item.Puntos)
                    {
                        maxPuntos = item.Puntos;
                    }
                    
                }
                //Verificamos que no paso de 100 si no se quita la vida y se
                foreach (var item in jugadores)
                {
                    //Si tiene vida pero sus puntos son mas de 100 o maximopuntaje
                    if (item.Vida && item.Puntos>Jugador.MAXIMO_PUNTAJE)
                    {
                        //Le quitamos la vida
                        item.Vida = false;
                        //Le asignamos el máximo de puntos
                        item.Puntos = (byte)maxPuntos;
                    }

                }
                ///si  no tiene vida y sus  sus puntos son mas de 100 o maximopuntaje 
                //Jugadores a eliminar
                List<Jugador> eliminados=new List<Jugador>();
                foreach (var item in jugadores)
                {
                    if (!(item.Vida) && item.Puntos > Jugador.MAXIMO_PUNTAJE)
                    {
                        Console.WriteLine("\tEste jugador es eliminado: " + item.Nombre);
                        //lo eliminamos de la lista
                        eliminados.Add(item);
                    } 
                }
                ///Eliminamos lo jugadores
                foreach (var item in eliminados)
                {
                    jugadores.Remove(item);
                }
                ///Ver los jugadores y sus cartas
                foreach (var item in jugadores)
                {
                    Console.WriteLine(item.ToString());
                    item.VerCartas();
                }
                if (jugadores.Count() <= 1) 
                {
                    final = true;
                }
                Console.ReadKey();
            }
            Console.WriteLine("\t\n**** El ganador es *******");
            foreach (var item in jugadores)
            {
                Console.WriteLine(item.ToString());
                item.VerCartas();
            }
            Console.WriteLine("\t**********************************");

        }
 
        /// <summary>
        /// Cambia una carta de la baraja del jugador por otra la última que llega de la mesa
        /// </summary>
        /// <param name="cartasEnLaMesa"></param>
        /// <param name="cartas"></param>
        private void Cambiar(List<Carta> cartasEnLaMesa, List<Carta> cartas)
        {
            Console.WriteLine("Escriba el número de la carta a cambiar [ 1-7 ]");
            byte opcion = 0;
            while (opcion==0)
            {
                try
                {
                    opcion = byte.Parse(Console.ReadLine());
                    if (!(opcion>0 && opcion<=7))
                    {
                        opcion = 0;
                    }
                }
                catch (Exception)
                {

                    opcion = 0;
                } 
            }
            Carta nueva = cartasEnLaMesa.ElementAt(cartasEnLaMesa.Count() - 1);
            Carta vieja = cartas.ElementAt(opcion - 1);
            vieja.Trio = false;
            vieja.Escalera = false;
            cartas.Remove(vieja);
            cartasEnLaMesa.Remove(nueva);
            cartas.Add(nueva);
            cartasEnLaMesa.Add(vieja);
            Baraja.Cartas.Insert(Baraja.Cartas.Count()-1, vieja);
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
            if (jugadores.Count() <=totalJugadores)
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
            if (jugadores.Count() <= totalJugadores)
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
