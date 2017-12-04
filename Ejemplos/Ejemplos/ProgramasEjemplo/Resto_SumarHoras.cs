using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplos.ProgramasEjemplo
{
    class Resto_SumarHoras
    {
        public Resto_SumarHoras()
        {
            Console.Write("Dime las hora actual \n-->");
            int hora = Convert.ToInt32(Console.ReadLine());
            Console.Write("Dime la hora a sumar \n-->");
            int suma = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("La suma de las horas es: "+((hora+suma)%24)+" horas");
            Console.ReadKey();

        }
    }
}
