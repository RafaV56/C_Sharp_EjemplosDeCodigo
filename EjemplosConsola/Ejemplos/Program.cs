using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplos
{
    class Program
    {
        static void Mai(string[] args)
        {
            //Entero
            int entero = 22;

            //Real
            double real = 22.5;

            //Lógico o Boleano
            bool boleano = true;

            //Caracter
            char caracter = 'ñ';

            //Cadena de texto
            string cadena = "cadena de texto";

            //Real corto
            float realCorto = 23.4332f;

            //Entero largo
            long enteroLargo = 2123123123;

            //Variable que debe ser inicializada con un valor, o dará error, se asume el valor que se le asigne
            var cualquiera = "hola";

            //debe ser inicializada con un valor, puede cambiar de tipo
            dynamic dinamica = "Otra variable";
            dinamica = 23;


            //Constantes. Debe ser inicializada con un valor cuando son declaradas
            const double PI = 3.14;

            //Escribe en pantalla con un salto de línea
            Console.WriteLine(dinamica);

            //Entrada de usuario, retorna un string
            Console.ReadLine();

            //Convertir un tipo a otro Convert.TOXXXX
            int otroEntero = Convert.ToInt32(dinamica);
            Console.WriteLine(otroEntero);

            //División
            //Si los operandos son enteros cualquier resto es omitido para retornar un valor entero.
            int division = 10 / 4;
            Console.WriteLine(division);//Retorna 2

            //Módulo o resto
            //retorna el resto de una división entera
            int resto = 25 % 7;
            Console.WriteLine(resto);//retorna 4

            //Operadores de asignación
            int x = 2;
            x += 2;
            x -= 3;
            Console.WriteLine(x);


            //Operadores realcioneles
            /*
             * >=  7 >= 4 Verdadero
             * <=  7 <= 4 Falso
             * ==  7 >= 4 Falso
             * !=  7 >= 4 Verdadero
             * */


            //Operadores aritméticos
            //Igual que en java


            //Operadores lógicos
            //igual que en java  && || !

            //Operador ternario o condicional
            //igual que en java ? :



            //CONTROL DE FLUJO
            //iF ELSE
            if (3 < 4)
            {
                Console.WriteLine("if ");
            }

            if (5 < 4)
            {
            }
            else
            {
                Console.WriteLine("if else ");
            }

            //Switch
            int num = 3;
            switch (num)
            {
                case 1:
                    Console.WriteLine("switch 1");
                    break;
                case 2:
                    Console.WriteLine("switch 2");
                    break;
                case 3:
                    Console.WriteLine("switch 3");
                    break;
                default:
                    Console.WriteLine("switch default");
                    break;
            }

            //While
            int num2 = 1;
            while (num2 < 6)
            {
                Console.WriteLine(num2);
                num2++;
            }

            //for
            for (int i = 10; i < 15; i++) //for (int i = 10; i < 15; i+=3)  otro ejemplo
            {
                Console.WriteLine(i);
            }

            //Do while

            do
            {
                Console.WriteLine(num2);
                num2++;
            } while (num2>333);




            Console.ReadKey();//lee solo un caracter
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
    }
}
