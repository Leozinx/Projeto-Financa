using ProjetoFinanca.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoFinanca.Infra.Mapeamento;

namespace ProjetoFinanca.Infra
{
    public class FinancaContexto : DbContext
    {
        public FinancaContexto() : base("name=TesteMovimentoPost")
        {

        }

        public DbSet<Movimentacao> Movimentos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Periodo> Periodos { get; set; }
        public DbSet<Menu> Menus { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MovimentoMap());
            modelBuilder.Configurations.Add(new CategoriaMap());
            modelBuilder.Configurations.Add(new PeriodoMap());
            modelBuilder.Configurations.Add(new MenuMap());

            modelBuilder.Entity<Movimentacao>()
                .HasRequired(c => c.Categoria)
                .WithMany(p => p.Movimentacao);

            base.OnModelCreating(modelBuilder);
        }
    }
}
