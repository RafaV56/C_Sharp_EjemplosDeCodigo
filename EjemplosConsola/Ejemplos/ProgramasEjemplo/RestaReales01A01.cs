using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplos.ProgramasEjemplo
{
    //Ejemplo de resta de números reales
    class RestaReales01A01
    {
        public RestaReales01A01()
        {
            Console.Write("si tienes ");
            Console.Write(1.20);
            Console.Write(" euros en el bolsillo");
            Console.Write(" y compras una bolsa de pipas ");
            Console.Write(0.35);
            Console.Write(" euros. te quedan ");
            Console.Write(1.20 - 0.35);
            Console.WriteLine(" euros");

            Console.Write("Si pepito tiene 7 manzanas y le la 1.5 manzanas a Juanito, le quedan "+(7-1.5));
            Console.WriteLine(" Manzanas");

            Console.WriteLine("si Pepito le da la mitad de sus manzanas a juanito? le queda "+(7/2.0));

            Console.ReadKey();


        }
        
    }
}
