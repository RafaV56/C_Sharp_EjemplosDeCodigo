using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplos.ProgramasEjemplo.enumEjemplos
{
    //creamos el enum
    public enum Palo
    {
        Oros,
        Bastos,
        Espadas,
        Copas
    }

    //Otros ejemplos de eum
    enum Day { Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday };
    //enum Day { Sat = 1, Sun, Mon, Tue, Wed, Thu, Fri };
    enum Month : byte { Jan, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep, Oct, Nov, Dec };
    // De forma predeterminada, el tipo subyacente de cada elemento de la enumeración 
    //es int. Puede especificar otro tipo numérico entero mediante el uso del signo de dos puntos
    //como en el siguiente ejemplo de days donde es un byte
    //enum Day : byte { Sat = 1, Sun, Mon, Tue, Wed, Thu, Fri };


    class EnumEjemplos
    {
        //Otro enum de ejemplo
        enum MachineState
        {
            PowerOff = 0,
            Running = 5,
            Sleeping = 10,
            //Puede asignar cualquier valor a los elementos de la 
            //lista de enumeradores de un tipo de enumeración, y también puede usar valores calculados:
            Hibernating = Sleeping + 5
        }

        public void Empezar()
        {
            //representamos una baraja, con las cartas que tiene el enum palo
            List<Carta> baraja = new List<Carta>();
            for (int i = 1; i <= 13; i++)
            {
                baraja.Add(new Carta(Palo.Bastos, i));
                baraja.Add(new Carta(Palo.Oros, i));
                baraja.Add(new Carta(Palo.Espadas, i));
                baraja.Add(new Carta(Palo.Copas, i));
            }

            Console.WriteLine("En este ejemplo de enum vamos a ver solo el palo de bastos Palo:"+(int)Palo.Bastos);
            foreach (var carta in baraja) 
            {
                //usamos el enum de Palo solo para ver los bastos
                if (carta.Palo==Palo.Bastos)
                {
                    Console.WriteLine(carta.ToString()); 
                }
            }
        }
    }

    struct Carta
    {
        public Palo Palo { get; set; }
        public int Numero { get; set; }

        public Carta(Palo Palo, int Numero)
        {
            this.Palo = Palo;
            this.Numero = Numero;
        }

        public override string ToString() => "Palo: " + Palo + " Número: " + Numero;
    }
}
