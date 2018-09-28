using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjetoFinanca.Modelo
{
    public class Periodo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataInicio { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataFim { get; set; }
        public decimal Valor { get; set; }
        public bool Situacao { get; set; }
        public virtual ICollection<Movimentacao> Movimentacao { get; set; }

    }
}