using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoFinanca.Web.Models
{
    public class MovimentaModel
    {
        public string Data_Mov { get; set; }
        public string Valor_Mov { get; set; }
        public string Descri_Mov { get; set; }
        public string Categoria_Mov { get; set; }
    }
}