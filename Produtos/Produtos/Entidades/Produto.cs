using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Produtos.Entidades
{
    public class Produto : Entidade
    {
        public string Descricao { get; set; }
        public double PrecoVenda { get; set; }
        public int SubGrupoId { get; set; }

        public virtual SubGrupo SubGrupo { get; set; }
    }
}
