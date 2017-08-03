using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Produtos.Entidades;

namespace Produtos.Persistencia.Mapeamentos
{
    public class GrupoMap
    {
        public GrupoMap(EntityTypeBuilder<Grupo> entityBuilder)
        {
            entityBuilder.Property(entidade => entidade.Descricao).HasMaxLength(200).IsRequired();
        }
    }
}
