using Produtos.ViewModels;

namespace Produtos.Entidades.Interfaces
{
    public interface ISubGrupoServico : IServico<SubGrupo, SubGrupoViewModel>
    {
        SubGrupo Salvar(SubGrupoViewModel viewModel);
        SubGrupo Excluir(int id);
    }
}
