using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinchon
{
    class Carta : IComparable<Carta>
    {
        //El numero de la carta en el palo
        public int Numero { get; set; }
        //Tiene que tener un Palo, corazones, diamantes etc...
        public Palo Palo { get; set; }
        /// <summary>
        /// True si pertenece a cuarteto  o trio del mismo número
        /// </summary>
        public bool Trio { get; set; }
        /// <summary>
        /// True si pertenece a escalera del mismo palo
        /// </summary>
        public bool Escalera { get; set; }

        public Carta(int Numero,Palo Palo)
        {
            this.Numero = Numero;
            this.Palo = Palo;
        }

        public override string ToString()
        {
            return "" + Palo + " : " + "["
                + (Numero == 1 ? "A" :
                Numero == 11 ? "J" :
                Numero == 12 ? "Q" :
                Numero == 13 ? "K" :
                Numero == 0 ? "?" :
                Convert.ToString(Numero)) + "]";//+"\t [Trios]:"+Trio+" \t[Escalera]:"+Escalera;
        }

        public int CompareTo(Carta other)
        {
            int suma = 0;

            if (other == null)
            {
                if (this == null)
                {
                    suma = 0;
                }
                else
                {
                    suma = -1;
                }
            }
            else if (this == null)
            {
                suma = 1;
            }
            else if (other.Palo == this.Palo)
            {
                if (other.Numero > this.Numero)
                {
                    suma = -1;
                }
                else if (other.Numero < this.Numero)
                {
                    suma = 1;
                }
                else
                {
                    suma = 0;
                }
            }
            else if (((int)other.Palo) > ((int)this.Palo))
            {
                suma = -1;
            }
            else
            {
                suma = 1;
            }
            return suma;
        }
    }
}
