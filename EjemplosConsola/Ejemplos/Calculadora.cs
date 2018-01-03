using Ejemplos.ProgramasEjemplo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplos
{
    class Calculadora
    {
        static void Main(string[] args)
        {

            Console.WriteLine(float.MinValue);
            Console.ReadKey();
            //MetodosOpcionalesSalidaRefenciaNombres resta = new MetodosOpcionalesSalidaRefenciaNombres();

            //Calculos calculadora = new Calculos();

            //calculadora.Menu();
        }
    }

    class Calculos
    {
        double total;
        double[] numeros;
        public Calculos()
        {
            numeros = new double[2]; 
        }

        public void Menu()
        {
            int eleccion;
            do
            {
                Console.WriteLine("Calculadora\n");
                Console.Write("1)Suma\n2)Resta\n\n0)Salir\n-->");
                try
                {
                    eleccion = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    eleccion = -1;                    
                }
                if (eleccion!=0)
                {
                    total = 0;
                    
                    switch (eleccion)
                    {
                        case 1:
                            PedirNumeros();
                            total = Suma(numeros[0], numeros[1]);
                            Console.WriteLine("La suma es: "+total);
                            break;
                        case 2:
                            PedirNumeros();
                            total = Resta(numeros[0], numeros[1]);
                            Console.WriteLine("La resta es: " + total);
                            break;
                        default:

                            Console.WriteLine("No es una elección correcta\n");
                            break;
                    }
                }
            } while (eleccion!=0);
        }

        private double Resta(double v1, double v2)
        {
            return v1 - v2;
        }

        private void PedirNumeros()
        {
            Console.WriteLine("Dame el numero uno");
            numeros[0] = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Dame el numero dos");
            numeros[1] = Convert.ToDouble(Console.ReadLine());
        }

        private double Suma(double uno,double dos)
        {
            return uno+dos;
        }

        //Destructor de la clase
        ~Calculos()
        {
            Console.WriteLine("Final de los cálculos");
            Console.ReadKey();
        }
    }
}
