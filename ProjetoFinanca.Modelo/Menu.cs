using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinanca.Modelo
{
    public class Menu
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Titulo { get; set; }
        public string Icon { get; set; }
        public bool Estado { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
    }
}
