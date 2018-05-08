using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SistemaSaldoAFavor.Models
{
    public class User
    {
        [Required(ErrorMessage = "Por Favor, Digite el Usuario")]
        public String UserName { get; set; }

        [Required(ErrorMessage = "Por Favor, Digite la Clave")]
        public String Pwd { get; set; }

    }
}