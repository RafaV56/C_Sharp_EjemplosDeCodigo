using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejemplos.ProgramasEjemplo.structEjemplos;

namespace Ejemplos.ProgramasEjemplo.structEjemplos
{
    class LaLupaMotos
    {
        public void Empezar()
        {
            var moto=new Moto("5678cnv",5200);
            int reparto=-1;
            while (reparto!=0)
            {
                Console.WriteLine("La matricula de la moto es: {0}", moto.Matricula.Trim().ToUpper());
                Console.WriteLine("Los kilometros recorridos por la moto son: {0}", moto.NumKilometros);
                Console.WriteLine("El dinero facturado es: {0}", moto.DineroFacturado);
                Console.WriteLine("Los kilómetros para la próxima revisión son: {0}", moto.KmFaltanRevision());
                Console.WriteLine("Vamos a simular un reparto, escribe los kilometros para el reparto");
                reparto = int.Parse(Console.ReadLine(), System.Globalization.NumberStyles.Float);
                moto.Repartir(reparto);
            }
        }
    }
}
