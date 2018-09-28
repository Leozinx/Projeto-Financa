using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoFinanca.Modelo;

namespace ProjetoFinanca.Infra.Mapeamento
{
    public class CategoriaMap : EntityTypeConfiguration<Categoria>
    {
        public CategoriaMap()
        {
            ToTable("Categoria");
            HasKey(c => c.Id);
            

            Property(c => c.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar")
                .HasMaxLength(10)
                .IsRequired();
            
        }
    }
}
