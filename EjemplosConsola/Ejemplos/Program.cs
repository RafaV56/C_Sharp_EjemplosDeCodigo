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
            //Enteros con signo ------------------------------------------------------

            //sbyte rango de -128 a 127
            sbyte sbyteMin = -128;
            sbyte sbyteMax = 127;
            //sbyte errorsByte = 128, error2Sbyte = -129;

            //short: 16 bits, de - 32,768 a 32,767
            short shortMin = -32768;
            short shortMax = 32767;
            //short errorsShort = -32769, error2Short = 32768;

            //int: 32 bits, de - 2,147,483,648 a 2,147,483,647
            int intMax = 2147483647;
            int intMin = -2147483648;
            //int errorInt = 2147483648, error2Int = -2147483649;

            //long: 64 bits, de - 9,223,372,036,854,775,808 a 9,223,372,036,854,775,807
            long longMax = 9223372036854775807;
            long longMin = -9223372036854775808;
            //long errorLong= 9223372036854775808, error2Long= -9223372036854775809;

            //------------------------------------------------------------------------

            //Enteros sin signo ------------------------------------------------------

            //byte 8 bits, de 0 a 255
            byte byteMin = 0;
            byte byteMax = 255;
            //byte errorByte = -1, error2byte = 256;

            //ushort: 16 bits, de 0 a 65,535
            ushort ushortMin = 0;
            ushort ushortMax = 65535;
            //ushort errorsUShort = -1, error2UShort = 65536;

            //uint: 32 bits, de 0 a 4,294,967,295
            uint uintMax = 4294967295;
            uint uintMin = 0;
            //uint errorUInt = -1, error2Int = 4294967296;

            //ulong: 64 bits, de 0 a 18,446,744,073,709,551,615
            ulong ulongMax = 18446744073709551615;
            ulong ulongMin = 0;
            //ulong errorULong= 18446744073709551616, error2ULong= -1;

            //------------------------------------------------------------------------

            //Punto flotante ------------------------------------------------------

            //float: 32 bits, de 1.5 × 10−45 a 3.4 × 1038, precisión de 7 dígitos

            float floatMin = -3.999f;

            //double: 64 bits, de 5.0 × 10−324 a 1.7 × 10308, precisión de 15 dígitos

            double doubleMin = double.MinValue;

            //decimal: 128 bits, al menos de –7.9 × 10−28 a 7.9 × 1028, con una precisión mínima de 28 dígitos

            decimal decimalMin = decimal.MinValue;

            //------------------------------------------------------------------------

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
