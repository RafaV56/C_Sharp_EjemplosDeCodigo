using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplos.ProgramasEjemplo
{
    class MetodosOpcionalesSalidaRefenciaNombres
    {
        public MetodosOpcionalesSalidaRefenciaNombres()
        {

            //_____________________________________________________________________________
            //ejemplo de un método con parametros opcionales
            Console.WriteLine("ejemplo de un método con parametros opcionales");

            Console.WriteLine(Potencia(6));//igual el segundo argumento a dos

            Console.WriteLine(Potencia(3, 4));
            //_____________________________________________________________________________

            //Ejemplo metodo con nombre
            Console.WriteLine("Ejemplo metodo con nombre");
            int varUno = 3;
            int varDos = 2;
            PorNombre(uno:varDos,dos:varUno);//salida igual a 4 y 9
            //_________________________________________________________________________________


            //Ejemplo metodo con refencia
            Console.WriteLine("Ejemplo metodo con refencia");
            int variableRefencia = 3;
            Sqr(ref variableRefencia);//salida igual a 9 por que cambio el valor de la variable a 3*3

            Console.WriteLine(variableRefencia);
            //_________________________________________________________________________________
            //Ejemplo metodo con Salida
            Console.WriteLine("Ejemplo metodo con Salida");
            int a, b;
            GetValues(out a, out b);//ahora a=5,b=8.

            Console.WriteLine(a+" "+b);

            //_________________________________________________________________________________
            Console.Write("Fin del programa");

            Console.ReadKey();
        }

        //Ejemplo de método por Nombre donde el valor de la variable cambiara según su nombre usando el nombre 
        //del argumento y los dos puntos
        void PorNombre(int uno, int dos)
        {
            uno= 2*uno;
            dos = 3*dos;
            Console.WriteLine(uno + " " + dos);
        }

        //Ejemplo de método por refencia donde el valor de la variable cambiara
        void Sqr(ref int x)//requiere la palabra ref al ser llamado también
        {
            x = x * x;
        }


        /*
        * Esto es un método con parametros opcioneales, cuando se llame
        * obligatoriamente se puede dar el parametro x, pero el y se puede omitir siendo 2
        * pero si le quieres dar otro valor se lo aceptará
       */
        int Potencia(int x, int y = 2)//tienen que ir al final de la lista de parametros los argumentos predeterminados
        {
            int resultado = 1;

            for (int i = 0; i < y; i++)
            {
                resultado *= x;
            }

            return resultado;
        }

        //Ejemplo de método por salida.
        void GetValues(out int x, out int y)//requiere la palabra out al ser llamado también, asigna el valor de x and y a las variables que le pasen
        {
            x = 5;
            y = 8;
        }


    }
}
