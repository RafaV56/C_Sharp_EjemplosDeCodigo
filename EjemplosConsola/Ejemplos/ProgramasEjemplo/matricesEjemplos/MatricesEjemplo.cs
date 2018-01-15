using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplos.ProgramasEjemplo.matricesEjemplos
{

    //Ejemplos de la documentación de Microsoft
    //https://docs.microsoft.com/es-es/dotnet/csharp/programming-guide/arrays/
    class MatricesEjemplo
    {
        public void Empezar()
        {
            //Puede declarar una matriz unidimensional de cinco enteros tal
            //y como se muestra en el ejemplo siguiente:
            int[] array = new int[5];

            // Es posible inicializar una matriz en la declaración, en cuyo caso,
            //el especificador de rango no es necesario porque ya lo proporciona 
            //el número de elementos de la lista de inicialización.Por ejemplo:
            int[] array1 = new int[] { 1, 3, 5, 7, 9 };
            //Se puede inicializar más fácil como en el siguiente ejemplo:
            string[] weekDays = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };

            //Es posible declarar una variable de matriz sin inicializarla, pero debe
            //usar el operador new al asignar una matriz a esta variable. Por ejemplo:
            int[] array3;
            array3 = new int[] { 1, 3, 5, 7, 9 };   // OK
            //array3 = {1, 3, 5, 7, 9};   // Error

            //Las matrices pueden tener varias dimensiones. Por ejemplo, la siguiente 
            //declaración crea una matriz bidimensional de cuatro filas y dos columnas.
            int[,] arrayMulti = new int[4, 2];

            //La siguiente declaración crea una matriz de tres dimensiones, 4, 2 y 3.
            int[,,] arrayTresDimensiones = new int[4, 2, 3];

            // Iniciar una matriz de dos dimensiones.
            int[,] array2D = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };
            // Iniciar una matriz de dos dimensiones con especificación.
            int[,] array2Da = new int[4, 2] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };
            // Igual pero con string.
            string[,] array2Db = new string[3, 2] { { "one", "two" }, { "three", "four" },
                                        { "five", "six" } };

            // Matriz de 3 dimensiones.
            int[,,] array3D = new int[,,] { { { 1, 2, 3 }, { 4, 5, 6 } },
                                 { { 7, 8, 9 }, { 10, 11, 12 } } };
            //  Matriz de 3 dimensiones especificada.
            int[,,] array3Da = new int[2, 2, 3] { { { 1, 2, 3 }, { 4, 5, 6 } },
                                       { { 7, 8, 9 }, { 10, 11, 12 } } };

            // Acceder a los elementos.
            System.Console.WriteLine(array2D[0, 0]);
            System.Console.WriteLine(array2D[0, 1]);
            System.Console.WriteLine(array2D[1, 0]);
            System.Console.WriteLine(array2D[1, 1]);
            System.Console.WriteLine(array2D[3, 0]);
            System.Console.WriteLine(array2Db[1, 0]);
            System.Console.WriteLine(array3Da[1, 0, 1]);
            System.Console.WriteLine(array3D[1, 1, 2]);

            // Getting the total count of elements or the length of a given dimension.
            var allLength = array3D.Length;
            var total = 1;
            for (int i = 0; i < array3D.Rank; i++)
            {
                total *= array3D.GetLength(i);
            }
            System.Console.WriteLine("{0} equals {1}", allLength, total);



            Console.WriteLine("Vamos  a crear una matriz de una dimensión int[] numbers = { 1, 2, 3, 4, 5 };");
            int[] numbers = { 1, 2, 3, 4, 5 };
            int lengthOfNumbers = numbers.Length;
            Console.WriteLine("vamos a recorla y vamos a ver cuantos elementos tiene");
            foreach (var numero in numbers)
            {
                Console.WriteLine("Número: " + numero);
            }
            Console.WriteLine("Tiene la matriz numbers: " + lengthOfNumbers + " elementos.");
            // Specify the data source.
            int[] scores = new int[] { 97, 92, 81, 60 };
            //La clase Array proporciona muchos otros métodos útiles y propiedades para ordenar, 
            //buscar y copiar matrices.

            // Declara e inicializa una matriz:
            int[,] theArray = new int[5, 10];
            System.Console.WriteLine("The array has {0} dimensions.", theArray.Rank);

            // Define the query expression.
            IEnumerable<int> scoreQuery =
                from score in scores
                where score > 80
                select score;

            // Execute the query.
            //foreach (int i in scoreQuery)
            //{
            //    Console.Write(i + " ");
            //}

          
        }
    }
}
