using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Produtos.Entidades;

namespace Produtos.Persistencia.Mapeamentos
{
    public class ProdutoMap
    {
        public ProdutoMap(EntityTypeBuilder<Produto> entityBuilder)
        {
            entityBuilder.Property(entidade => entidade.Descricao).HasMaxLength(200).IsRequired();
        }
    }
}
