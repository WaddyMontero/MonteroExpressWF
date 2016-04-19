using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonteroExpressWF.BOL
{
    public class PaqueteEnvio
    {
        public int IdPaqueteEnvio { get; set; }
        public Nullable<int> IdEnvio { get; set; }
        public int Cantidad { get; set; }
        public int IdTamanioPaquete { get; set; }
        public string Descripcion { get; set; }
        //public Nullable<decimal> PrecioUnitario { get; set; }
        public decimal Peso { get; set; }
        public int IdEstado { get; set; }

        //Campos Utilizados Para El JTable
        public string TamanoPaquete { get; set; }
        public string EstadoPaquete { get; set; }
        public string ValorEnvio { get; set; }


        //public TipoPaquete Tama { get; set; }


        public TamanioPaquete TamanioPaquete { get; set; }
        public Estado Estado{ get; set; }
        //public TipoPaquete Tama { get; set; }

    }
}