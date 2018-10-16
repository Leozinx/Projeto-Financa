using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoFinanca.Infra;
using ProjetoFinanca.Repositorio.Abstrato;

namespace ProjetoFinanca.Repositorio.Concreto
{
    public class RepositorioBase<TEntity> : IDisposable, IRepositorio<TEntity> where TEntity : class
    {
        private FinancaContexto Db = new FinancaContexto();

        public RepositorioBase()
        {
            Db.Configuration.ProxyCreationEnabled = false;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Adicionar(TEntity objeto)
        {
            Db.Set<TEntity>().Add(objeto);
            Db.SaveChanges();
        }


        public void Excluir(TEntity objeto)
        {
            Db.Set<TEntity>().Remove(objeto);
        }

        public TEntity Buscar(int codigo)
        {
            return Db.Set<TEntity>().Find(codigo);
        }

        public IEnumerable<TEntity> BuscarTodos()
        {
            return Db.Set<TEntity>().ToList();
        }

        public void atualizar(TEntity objeto)
        {
            Db.Entry(objeto).State = EntityState.Modified;
            Db.SaveChanges();
        }
    }
}
