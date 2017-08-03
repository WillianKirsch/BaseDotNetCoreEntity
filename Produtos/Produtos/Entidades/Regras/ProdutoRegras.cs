using Produtos.Entidades.Mensagens;
using Produtos.Infraestrutura.Extensions;
using Produtos.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Produtos.Entidades.Regras
{
    public class ProdutoRegras
    {
        public static IEnumerable<string> ValidarParaSalvar(ProdutoViewModel viewModel, IQueryable<Produto> produtos)
        {
            if (string.IsNullOrWhiteSpace(viewModel.Descricao))
                yield return Mensagem.ParametroObrigatorio.Formatar(Termo.Descricao);

            if (PossuiProdutoPorDescricao(produtos, viewModel.Id, viewModel.Descricao))
                yield return Mensagem.EntidadeDuplicada.Formatar(Termo.Descricao);
        }

        public static IEnumerable<string> ValidarParaExcluir(Produto entidade)
        {
            if (entidade == null)
                yield return Mensagem.EntidadeNaoEncontrada.Formatar(Termo.Produto);
        }

        private static bool PossuiProdutoPorDescricao(IQueryable<Produto> produtos, int id, string descricao)
        {
            return produtos.Any(produto =>
                    (id == 0 || produto.Id != id) &&
                    produto.Descricao.ToLower().Equals(descricao.ToLower()));
        }
    }
}
