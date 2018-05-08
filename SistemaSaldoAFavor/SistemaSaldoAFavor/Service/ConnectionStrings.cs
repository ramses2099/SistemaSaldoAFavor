using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;


namespace SistemaSaldoAFavor.Service
{
    public class ConnectionStrings
    {
        //
        public static string ConnectionString
        {
            get
            {
                
                return ConfigurationManager.ConnectionStrings["PortalHITConnectionString"].ConnectionString;
            }
        }

    }
}