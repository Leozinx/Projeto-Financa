using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoFinanca.Web.Models
{
    public class MovimentoPeriodo
    {
        public string periodo { get; set; }
        public List<MovimentoCategoria> _movimentoCategoria { get; set; }

        public MovimentoPeriodo()
        {
            _movimentoCategoria = new List<MovimentoCategoria>();
        }
    }

    public class MovimentoCategoria
    {
        public string categoria { get; set; }
        public decimal Valor { get; set; }
    }
}