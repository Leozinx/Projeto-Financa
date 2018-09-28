using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinanca.Modelo
{
    public class Movimentacao
    {
        public int Id { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public string Descricao { get; set; }
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
        public int PeriodoId { get; set; }
        public virtual Periodo Periodo { get; set; }
    }
}
