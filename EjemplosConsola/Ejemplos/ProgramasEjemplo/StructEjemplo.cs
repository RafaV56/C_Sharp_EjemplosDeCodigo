using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplos.ProgramasEjemplo
{
    // las estructuras son de tipo valor, si la paso por parametros no se modifican sus variables se pasa una
    //copia de la estructura. tampoco es necesario usar new, es como si fuera una variable int;
    struct StructEjemplo
    {
        public int x;
        public int y;
        public int z;

        //No se puede inicializar una variable a menos que  sea constante o estatica
        //public int a = 0;
        public static int j = 0;
        private const int H = 5;

        //no se puede crear un destructor
        

        /*
         * No se puede crear un constructor sin parametros
        public StructEjemplo()
        {
            
        }
        */

        //constructor con parametros se deben asignar las variables obligatoriamente
        public StructEjemplo(int p)
        {
            x = 1;
            y = 2;
            z = p;
        }
    }
}
