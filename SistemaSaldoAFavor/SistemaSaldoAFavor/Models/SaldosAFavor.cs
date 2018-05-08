using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaSaldoAFavor.Models
{
    public class SaldosAFavor
    {
        public int IdSaldosAFavor { get; set; }
        public String Servicio { get; set; }
        public String Recibo { get; set; }
        public String Fecha { get; set; }
        public String RNC { get; set; }
        public String Cliente { get; set; }
        public String Usuario { get; set; }
        public String TipoPago { get; set; }
        public String MontoRecibo { get; set; }
        public String MontoAFavor { get; set; }
        public String SaldoDisponible { get; set; }
        public String Estatus { get; set; }
        public String Anular { get; set; }
        public String Comentario { get; set; }
        public String MontoDisponible { get; set; }
        public String MontoAAplicar { get; set; }


    }
}