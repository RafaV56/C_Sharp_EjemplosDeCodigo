using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinchon
{
    class Jugador
    {
        public static byte MAXIMO_CARTAS = 7;
        //Máximo puntaje que puede tener un jugador
        public static byte MAXIMO_PUNTAJE = 100;
        /// <summary>
        /// Emperazara a true pero Si pasa de Máximo puntaje pasa false
        /// </summary>
        public bool Vida { get; set; }
        //Nombre del jugador
        public string Nombre { get; set; }
        //Puntos del jugador
        public byte Puntos { get; set; }
        /// <summary>
        /// True si no es un jugador Principal
        /// </summary>
        public bool JugadorMaquina { get; set; }
        /// <summary>
        /// Cartas de la mano
        /// </summary>
        public List<Carta> Cartas { get; set; }

        /// <summary>
        /// <c>Jugador</c> 
        /// es el constructor <c>Jugador</c> struct.
        /// </summary>
        /// <param name="Nombre">Nombre del jugador</param>  
        public Jugador(string Nombre, bool JugadorMaquina)
        {
            this.Nombre = Nombre;
            Vida = true;
            Puntos = 0;
            this.JugadorMaquina = JugadorMaquina;
            Cartas = new List<Carta>();
        }

        public override string ToString() => "\n*** [" + Nombre.ToUpper() + "] [#: " + Puntos + "] [Vida: " + (Vida ? "Si] ***" : "No] ***");

        public void AgregarCarta(Carta carta)
        {
            if (Cartas.Count() < MAXIMO_CARTAS)
            {
                Cartas.Add(carta);
            }
            else
            {
                Console.WriteLine("La carta no se puede agregar a este jugador " + Nombre);
            }
        }

        public void VerCartas()
        {
            int contador = 0;
            //Cartas.Sort();
            //Puedo ver la lista más fácil
            foreach (var carta in Cartas)
            {
                Console.WriteLine("\t{0}) {1}", ++contador, carta.ToString());
            }

        }

        /// <summary>
        /// Suma los puntos que tiene la mano
        /// </summary>
        /// <returns>Puntos de la mano</returns>
        public int PuntosTotalesMano()
        {
            //Puntos en la mano
            int puntos = 0;
            //Array para saber que números se repiten
            byte[] veces = new byte[14];

            //ordeno las cartas para ver si tienen un chinchon, cuarteto o trio
            Cartas.Sort();
            //Array para saber por palo que cartas se tienen.
            bool[,] paloMano = new bool[5, 15];
            //Asignamos la cartar en el array para saber si van a estar seguidas, y ver si tienen trio
            foreach (var carta in Cartas)
            {
                //Según la carta se asigna true a su posición en el array palomano
                paloMano[(int)carta.Palo, carta.Numero] = true;
            }
            //buscamos el trio chinchon o cuarteto etc...   
            for (int i = 0; i < 5; i++)
            {
                //contador para saber cuantas cartas tiene repetidas un palo
                int contadorCartas = 0;
                Palo palo;
                if (i == 0)
                {
                    palo = Palo.CORAZONES;
                }
                else if (i == 1)
                {
                    palo = Palo.DIAMANTES;
                }
                else if (i == 2)
                {
                    palo = Palo.PICAS;
                }
                else if (i == 3)
                {
                    palo = Palo.TREBOLES;
                }
                else
                {
                    palo = Palo.JOKER;
                }
                //Tenemos el palo ahora buscamos la cartas repetidas por palo
                for (int sub = 0; sub < 15; sub++)
                {
                    if (paloMano[i, sub])
                    {
                        contadorCartas++;
                    }
                    else
                    {
                        if (contadorCartas < 3)
                        {
                            contadorCartas = 0;
                        }
                        else
                        {
                            //si tenemos más de tres, hay escalera, recorremos las cartas y  ponemos a true el atributo escalera
                            //tres sera el número donde empiezan la escalera
                            for (int tres = (sub - contadorCartas); tres < sub; tres++)
                            {
                                //recorremos las cartas en busca de la carta que tenga el palo y número
                                for (int cuatr = 0; cuatr < Cartas.Count(); cuatr++)
                                {
                                    if (Cartas.ElementAt(cuatr).Palo == palo && Cartas.ElementAt(cuatr).Numero == tres)
                                    {
                                        Cartas.ElementAt(cuatr).Escalera = true;
                                        break;
                                    }
                                }
                            }
                            //contador vuelve a ser cero
                            contadorCartas = 0;
                        }

                    }
                }

            }
            //Ver los bool de el palo
            //for (int i = 0; i < 5; i++)
            //{
            //    for (int sub = 0; sub < 14; sub++)
            //    {
            //        Console.Write("fila={0} y col={1}, bool={2}\n", i, sub, paloMano[i, sub]);
            //    }
            //}

            //Vamos a ver los trios pero que no pertenezcan a una escalera
            foreach (var carta in Cartas)
            {
                if (!carta.Escalera)
                {
                    veces[carta.Numero]++;
                }

            }
            //Ver las cartas que tienes repetidas según cada número
            //for (int i = 1; i < veces.Length; i++)
            //{
            //    Console.WriteLine("puntos en mano" + i + " veces: " + veces[i]);
            //}
            for (int i = 0; i < veces.Length; i++)
            {
                if (!(veces[i] >= 3))
                {
                    if (i <= 10)
                    {
                        puntos += i * veces[i];
                    }
                    else
                    {
                        puntos += 10 * veces[i];
                    }
                }
                else
                {
                    for (int sub = 0; sub < Cartas.Count(); sub++)
                    {
                        if (Cartas.ElementAt(sub).Numero == i)
                        {
                            Carta nueva = Cartas.ElementAt(sub);
                            nueva.Trio = true;
                            Cartas.Remove(nueva);
                            Cartas.Insert(0, nueva);
                        }
                    }
                }
            }
            return puntos;
        }
        /// <summary>
        /// Retorna true si el jugador tiene 1 o 0 cartas que no pertenecen a una trio o escalera
        /// </summary>
        /// <returns>se puede bajar</returns>
        public bool SeisCartas()
        {
            bool unaCarta = false;
            int dos = 0;
            ///busco las cartas las que no tienen trio y escalera y sumo a dos
            foreach (var item in Cartas)
            {
                if (!item.Trio && !item.Escalera)
                {
                    dos++;
                }
            }
            if (dos<=1)
            {
                unaCarta = true;
            }
            return unaCarta;
        }

        public void SumarPuntos()
        {
            Puntos += (byte)PuntosTotalesMano();
        }
    }
}
