using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonteroExpressWF.BOL
{
    public class Envio
    {
        public int IdEnvio { get; set; }
        public DateTime Fecha { get; set; }
        public string AlbaranNum { get; set; }
        public int IdPuertoOrigen { get; set; }
        public int IdPuertoDestino { get; set; }
        public string RecogidoPor { get; set; }
        public string Ruta { get; set; }

        public Entidad Remitente { get; set; }
        public Entidad Destinatario { get; set; }
        public decimal Valor { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string NumeroEnvio { get; set; }
        public int IdOficina { get; set; }

        public Oficina Oficina { get; set; }
        public int IdSeguro { get; set; }
        public SeguroEnvio SeguroEnvio { get; set; }
        public List<PaqueteEnvio> PaquetesEnvios { get; set; }
        public List<TipoContenido> TiposContenidos { get; set; }

        //Campos Utilizados Para El JTable

        public string direccionRemitente { get; set; }
        public string direccionDestinatario { get; set; }
        public string nombreRemitente { get; set; }
        public string nombreDestinatario { get; set; }
        public string descripcionSeguro { get; set; }
        public string nombrePuertoDestino { get; set; }
        public string nombrePuertoOrigen{ get; set; }

        public string FechaString { get; set; }
        public Int32 IdEstado { get; set; }
    }
}