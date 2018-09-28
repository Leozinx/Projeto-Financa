using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoFinanca.Modelo;

namespace ProjetoFinanca.Infra.Mapeamento
{
    public class MenuMap : EntityTypeConfiguration<Menu>
    {
        public MenuMap()
        {
            ToTable("Menu");
            HasKey(c => c.Id);

            Property(c => c.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsRequired();

            Property(c => c.Titulo)
                .HasColumnName("Titulo")
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsRequired();

            Property(c => c.Icon)
                .HasColumnName("icone_nome")
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsRequired();

        }
    }
}
