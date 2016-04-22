using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MonteroExpressWF.BOL;
using MonteroExpressWF.DAL;

namespace MonteroExpressWF.BLL
{
    public class ManejadorGraficas
    {
        public static List<KeyValuePair<int, string>> TotalEnviosPorMes() 
        {
            return ManejadorMonteroExpress.TotalEnviosPorMes();
        }
        public static List<KeyValuePair<string, string>> Top5Envios() 
        {
            return ManejadorMonteroExpress.Top5Envios();
        }
        public static List<KeyValuePair<string, string>> Top5Recepciones() 
        {
            return ManejadorMonteroExpress.Top5Recepciones();
        }
        
    }
}