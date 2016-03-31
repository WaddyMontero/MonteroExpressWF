using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonteroExpressWF.BOL
{
    public class Envio
    {
        public int IdEnvio { get; set; }
        public System.DateTime Fecha { get; set; }
        public string AlbaranNum { get; set; }
        public Entidad Remitente { get; set; }
        public Entidad Destinatario { get; set; }
        public decimal Valor { get; set; }
        public Nullable<System.DateTime> FechaIngreso { get; set; }

        public EstadoEnvio EstadoEnvio { get; set; }
        public Oficina Oficina { get; set; }
        public SeguroEnvio SegurosEnvio { get; set; }
        public List<PaqueteEnvio> PaquetesEnvios { get; set; }
        public List<TipoContenido> TiposContenidos { get; set; }
    }
}