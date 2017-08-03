using Produtos.ViewModels;

namespace Produtos.Entidades.Interfaces
{
    public interface IGrupoServico : IServico<Grupo, GrupoViewModel>
    {
        Grupo Salvar(GrupoViewModel viewModel);
        Grupo Excluir(int id);
    }
}
