using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinchon
{
    struct Baraja
    {
        public List<Carta> Cartas { get; set; }
        public byte CartasPorPalo { get; set; }

        public Baraja(byte CartasPorPalo)
        {
            this.CartasPorPalo = CartasPorPalo;
            Cartas = new List<Carta>();
            for (byte i = 1; i <= CartasPorPalo; i++)
            {
                Cartas.Add(new Carta(i, Palo.CORAZONES));
                Cartas.Add(new Carta(i, Palo.DIAMANTES));
                Cartas.Add(new Carta(i, Palo.TREBOLES));
                Cartas.Add(new Carta(i, Palo.PICAS));
            }
        }

        public void VerBaraja()
        {
            foreach (var carta in Cartas)
            {
                Console.WriteLine(carta.ToString());
            }
        }

        public void Barajar()
        {
            Random op = new Random();
            int insertar;
            for (int i = 0; i < 1000; i++)
            {
                insertar= op.Next(Cartas.Count()-1);
                Carta nueva = Cartas.ElementAt(0);
                Cartas.Remove(nueva);
                Cartas.Insert(insertar,nueva);
            }
        }

        public Carta DarCarta()
        {
            Carta carta = Cartas.ElementAt(0);
            Cartas.Remove(carta);
            return carta;
        }
    }
}
