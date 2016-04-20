using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MonteroExpressWF.BOL;
using MonteroExpressWF.DAL;

namespace MonteroExpressWF.BLL
{
    public class ManejadorUsuarios
    {
        public static Usuario AutenticarUsuario(string Usuario,string Contrasena)
        {
            return ManejadorMonteroExpress.AutenticarUsuario(Usuario,Contrasena);
        }
    }
}