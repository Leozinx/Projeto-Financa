using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoFinanca.Modelo;

namespace ProjetoFinanca.Infra.Mapeamento
{
    public class MovimentoMap : EntityTypeConfiguration<Movimentacao>
    {
        public MovimentoMap()
        {
            ToTable("Movimentacao");
            HasKey(c => c.Id);

            Property(c => c.Data)
                .HasColumnName("Data")
                .IsRequired();

            Property(c => c.Descricao)
                .HasColumnName("Descricao")
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsRequired();

            Property(x => x.Valor)
                .HasPrecision(7, 2)
                .IsRequired();
        }
    }
}
