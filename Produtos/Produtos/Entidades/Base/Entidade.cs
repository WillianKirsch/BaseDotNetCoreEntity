using System.ComponentModel.DataAnnotations;

namespace Produtos.Entidades
{
    public abstract class Entidade
    {
        [Key]
        public int Id { get; set; }
    }
}
