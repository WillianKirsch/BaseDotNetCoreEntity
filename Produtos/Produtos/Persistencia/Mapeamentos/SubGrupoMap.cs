using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Produtos.Entidades;

namespace Produtos.Persistencia.Mapeamentos
{
    public class SubGrupoMap
    {
        public SubGrupoMap(EntityTypeBuilder<SubGrupo> entityBuilder)
        {
            entityBuilder.Property(entidade => entidade.Descricao).HasMaxLength(200).IsRequired();
        }
    }
}
