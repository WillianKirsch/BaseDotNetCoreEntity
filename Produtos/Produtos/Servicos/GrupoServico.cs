using Produtos.Entidades;
using Produtos.Entidades.Interfaces;
using Produtos.Entidades.Regras;
using Produtos.Persistencia.Contexto;
using Produtos.ViewModels;
using System;
using System.Collections.Generic;

namespace Produtos.Servicos
{
    public class GrupoServico : Servico<Grupo, GrupoViewModel>, IGrupoServico
    {
        public GrupoServico(Contexto contexto) : base(contexto)
        {
        }

        public Grupo Salvar(GrupoViewModel viewModel)
        {
            Func<IEnumerable<string>> metodoParaValidarViewModel = (() => GrupoRegras.ValidarParaSalvar(viewModel, this.ObterTodos()));
            return base.Salvar(viewModel, metodoParaValidarViewModel, GrupoExtension.TransformarViewEmModel);
        }

        public Grupo Excluir(int id)
        {
            return base.Excluir(id, GrupoRegras.ValidarParaExcluir);
        }
    }
}
