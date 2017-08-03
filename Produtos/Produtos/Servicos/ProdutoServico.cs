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
    public class ProdutoServico : Servico<Produto, ProdutoViewModel>, IProdutoServico
    {
        public ProdutoServico(Contexto contexto) : base(contexto)
        {
        }

        public override IQueryable<Produto> ObterTodos()
        {
            return Contexto.Produtos.Include(produto => produto.SubGrupo.Grupo);
        }

        public override Produto ObterPorId(int id)
        {
            return Contexto.Produtos.Include(produto => produto.SubGrupo.Grupo)
                                    .FirstOrDefault(produto => produto.Id == id);
        }

        public Produto Salvar(ProdutoViewModel viewModel)
        {
            Func<IEnumerable<string>> metodoParaValidarViewModel = (() => ProdutoRegras.ValidarParaSalvar(viewModel, this.ObterTodos()));
            return base.Salvar(viewModel, metodoParaValidarViewModel, ProdutoExtension.TransformarViewEmModel);
        }

        public Produto Excluir(int id)
        {
            return base.Excluir(id, ProdutoRegras.ValidarParaExcluir);
        }
    }
}
