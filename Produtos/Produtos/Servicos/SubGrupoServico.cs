using Microsoft.EntityFrameworkCore;
using Produtos.Entidades;
using Produtos.Entidades.Interfaces;
using Produtos.Entidades.Regras;
using Produtos.Persistencia.Contexto;
using Produtos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Produtos.Servicos
{
    public class SubGrupoServico : Servico<SubGrupo, SubGrupoViewModel>, ISubGrupoServico
    {
        public SubGrupoServico(Contexto contexto) : base(contexto)
        {
        }

        public override IQueryable<SubGrupo> ObterTodos()
        {
            return Contexto.SubGrupos.Include(subGrupo => subGrupo.Grupo);
        }

        public override SubGrupo ObterPorId(int id)
        {
            return Contexto.SubGrupos.Include(subGrupo => subGrupo.Grupo)
                                     .FirstOrDefault(subGrupo => subGrupo.Id == id);
        }

        public SubGrupo Salvar(SubGrupoViewModel viewModel)
        {
            Func<IEnumerable<string>> metodoParaValidarViewModel = (() => SubGrupoRegras.ValidarParaSalvar(viewModel, this.ObterTodos()));
            return base.Salvar(viewModel, metodoParaValidarViewModel, SubGrupoExtension.TransformarViewEmModel);
        }

        public SubGrupo Excluir(int id)
        {
            return base.Excluir(id, SubGrupoRegras.ValidarParaExcluir);
        }
    }
}
