using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoFinanca.Modelo;

namespace ProjetoFinanca.Infra.Mapeamento
{
    public class PeriodoMap : EntityTypeConfiguration<Periodo>
    {
        public PeriodoMap()
        {
            ToTable("Periodo");
            HasKey(c => c.Id);

            Property(c => c.DataInicio)
                .HasColumnName("Inicio")
                .IsRequired();

            Property(c => c.DataFim)
                .HasColumnName("Fim")
                .IsRequired();

            Property(x => x.Valor)
                .HasPrecision(7, 2);

            Property(c => c.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsRequired();
        }
    }
}
