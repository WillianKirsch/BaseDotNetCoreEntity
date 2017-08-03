using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Produtos.Entidades
{
    public class SubGrupo : Entidade
    {
        public string Descricao { get; set; }
        public int GrupoId { get; set; }

        public virtual Grupo Grupo { get; set; }
    }
}
