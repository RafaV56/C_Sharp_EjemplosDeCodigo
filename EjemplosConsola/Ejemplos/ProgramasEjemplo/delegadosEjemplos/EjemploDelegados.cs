using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplos.ProgramasEjemplo.delegadosEjemplos
{
    class EjemploDelegados
    {
        //Creamos un delegado
        public delegate void Del(string message);

        public void Empezar()
        {
            //creamos un objeto delegado
             Del del = Escribir;//Le asignamos el metodo escribir sin necesidad de los parametros
           // Del del = new Del(Escribir);//otra forma de crear el obj del
            del("texto desde el programa principal");//LLamamos al delegado y pasamos el parametro como texto


            //tambien se puede enviar delegados como parametros
            MethodWithCallback(1, 2, del);//El metodo acepta un delegado, le pasamos del creado anteriormente

            //Se puede crear un delegados con varias delegados
            MethodClass obj = new MethodClass();//Creamos un obj de la clase con dos metodos 
            Del d1 = obj.Method1;//creamos un delegado llamado d1
            Del d2 = obj.Method2;//creamos un delegado llamado d1

            //Both types of assignment are valid.
            Del allMethodsDelegate = d1 + d2;
            allMethodsDelegate += del;

            //se puede llamar al método que te dice cuantos delegados tiene el obj
            int invocationCount = allMethodsDelegate.GetInvocationList().GetLength(0);
            Console.WriteLine("El delegado allmethodsDelegate tiene  " + invocationCount+" delegados");

            allMethodsDelegate("all methods");

            //Si el delegado usa parámetros de referencia, la referencia se pasa secuencialmente a cada uno
            //    de los tres métodos por turnos, y cualquier cambio que realice un método es visible para el
            //    siguiente método. Cuando alguno de los métodos produce una excepción que no se captura dentro
            //    del método, esa excepción se pasa al llamador del delegado y no se llama a los métodos siguientes
            //    de la lista de invocación.Si el delegado tiene un valor devuelto o los parámetros de salida,
            //    devuelve el valor devuelto y los parámetros del último método invocado. Para quitar un método
            //    de la lista de invocación, utilice el operador de decremento o el operador de asignación de 
            //    decremento('-' o '-= '). Por ejemplo:
            //remove Method1
            allMethodsDelegate -= d1;

            // copy AllMethodsDelegate while removing d2
            Del oneMethodDelegate = allMethodsDelegate - d2;


            // Crear un delegado con un metodo anónimo.
            Del del3 = delegate (string name)
            { Console.WriteLine("Notification received for: {0}", name); };

            //Crear un delegado con una expresión lambda.
            Del del4 = name => { Console.WriteLine("Notification received for: {0}", name); };

            del4("del 4");
        }

        public void Escribir(string msn)
        {
            Console.WriteLine("Este es el metodo escribir y el parametro es: " + msn);
        }

        //Metodo que acepta un delegado como parametro
        public void MethodWithCallback(int param1, int param2, Del callback)
        {
            callback("La suma de los números es: " + (param1 + param2).ToString());
        }
    }

    public class MethodClass
    {
        public void Method1(string message) {
            Console.WriteLine("Este es el metodo1 y el parametro es: " + message);
        }
        public void Method2(string message) {
            Console.WriteLine("Este es el metodo2 y el parametro es: " + message);
        }
    }
}
