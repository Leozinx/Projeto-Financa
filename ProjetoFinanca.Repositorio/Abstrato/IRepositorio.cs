using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinanca.Repositorio.Abstrato
{
    public interface IRepositorio<TEntity> where TEntity: class
    {
        void Adicionar(TEntity objeto);
        void Excluir(TEntity objeto);
        TEntity Buscar(int codigo);
        IEnumerable<TEntity> BuscarTodos();
        void atualizar(TEntity objeto);
    }
}
