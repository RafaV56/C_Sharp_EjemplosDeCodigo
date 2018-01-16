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
        //Emperazara a true pero Si pasa de Máximo puntaje pasa false
        public bool Vida { get; set; }
        //Nombre del jugador
        public string Nombre { get; set; }
        //Puntos del jugador
        public byte Puntos { get; set; }
        /// <summary>
        /// True si no es un jugador Principal
        /// </summary>
        public bool JugadorMaquina { get; set; }
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

        public override string ToString() => "\nNombre: " + Nombre + " Puntos: " + Puntos + " Vida: " + (Vida ? "Si" : "No") + " Cartas: ";

        public void AgregarCarta(Carta carta)
        {
            if (Cartas.Count()<MAXIMO_CARTAS)
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
            Cartas.Sort();
            //Puedo ver la lista más fácil
            Cartas.ForEach(Console.WriteLine);
        }

    }
}
