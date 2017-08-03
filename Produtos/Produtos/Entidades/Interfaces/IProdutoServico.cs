using Produtos.ViewModels;

namespace Produtos.Entidades.Interfaces
{
    public interface IProdutoServico : IServico<Produto, ProdutoViewModel>
    {
        Produto Salvar(ProdutoViewModel viewModel);
        Produto Excluir(int id);
    }
}
