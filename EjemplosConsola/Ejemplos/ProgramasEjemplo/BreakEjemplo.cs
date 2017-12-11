using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplos.ProgramasEjemplo
{
    class BreakEjemplo
    {
        public BreakEjemplo()
        {
            Console.Write("ejemplo de break en un bucle");

            for (int i = 0; i < 10; i++)
            {
                
                if (i==5)
                {
                    break;
                    //continue; Saltaría a la próxima iteración
                }
                Console.WriteLine(i);
            }
            Console.Write("Fin del programa");

            Console.ReadKey();
        }
    }
}
