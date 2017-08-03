using Produtos.Entidades;

namespace Produtos.ViewModels
{
    public class ProdutoViewModel : ViewModel
    {
        public string Descricao { get; set; }
        public double PrecoVenda { get; set; }
        public int SubGrupoId { get; set; }
        public SubGrupoViewModel SubGrupoViewModel { get; set; }
    }

    public static class ProdutoExtension
    {
        public static Produto TransformarEmModel(this ProdutoViewModel viewModel, Produto entidade)
        {
            entidade.Id = viewModel.Id;
            entidade.Descricao = viewModel.Descricao;
            entidade.PrecoVenda = viewModel.PrecoVenda;
            entidade.SubGrupoId = viewModel.SubGrupoId;

            return entidade;
        }

        public static Produto TransformarViewEmModel(ProdutoViewModel viewModel, Produto entidade)
        {
            return viewModel.TransformarEmModel(entidade);
        }

        public static ProdutoViewModel TransformarEmViewModel(this Produto entidade)
        {
            return new ProdutoViewModel
            {
                Id = entidade.Id,
                Descricao = entidade.Descricao,
                PrecoVenda = entidade.PrecoVenda,
                SubGrupoId = entidade.SubGrupoId,
                SubGrupoViewModel = entidade.SubGrupo?.TransformarEmViewModel()
            };
        }
    }
}
