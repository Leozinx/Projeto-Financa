﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoFinanca.Modelo;
using ProjetoFinanca.Repositorio.Abstrato;

namespace ProjetoFinanca.Repositorio.Concreto
{
    public class EFMovimenta : RepositorioBase<Movimentacao>, IMovimenta
    {
        public void AdicionarTodos(IEnumerable<Movimentacao> objeto)
        {
            foreach (var VARIABLE in objeto)
            {
                Adicionar(VARIABLE);
            }
        }
    }
}
