using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplos.ProgramasEjemplo.structEjemplos
{
    struct Moto
    {
        //Las variables estáticas tiene que ser inicializadas
        //Kilometros a lo que se hace la revisión
        public static int Revision = 10000;
        //Precio por kilómetro
        public static double PrecioKilometro = 2.5;


        //Matricula de la moto
        public string Matricula { get; set; }
        //Kilometros recorridos de la moto
        public int NumKilometros { get; set; }
        //Dinero Facturado
        public double DineroFacturado { get; set; }

        //Suma los kilometros de reparto a la moto
        public void Repartir(int kmDestino)
        {
            NumKilometros += kmDestino;
            DineroFacturado += kmDestino * PrecioKilometro;
        }

        //Constructor
        public Moto(string Matricula,int NumKilometros)
        {
            this.Matricula = Matricula;
            this.NumKilometros = NumKilometros;
            DineroFacturado = 0;
        }

        //Devuelve los kilómetros que faltan hasta la próxima revisión
        public int KmFaltanRevision()
        {
            int Revi = Revision- (NumKilometros%Revision);
            return Revi;
        }

        

        


    }
}
