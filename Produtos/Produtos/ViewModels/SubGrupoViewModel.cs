using Produtos.Entidades;

namespace Produtos.ViewModels
{
    public class SubGrupoViewModel : ViewModel
    {
        public string Descricao { get; set; }
        public int GrupoId { get; set; }
        public GrupoViewModel GrupoViewModel { get; set; }
    }

    public static class SubGrupoExtension
    {
        public static SubGrupo TransformarEmModel(this SubGrupoViewModel viewModel, SubGrupo entidade)
        {
            entidade.Id = viewModel.Id;
            entidade.Descricao = viewModel.Descricao;
            entidade.GrupoId = viewModel.GrupoId;

            return entidade;
        }

        public static SubGrupo TransformarViewEmModel(SubGrupoViewModel viewModel, SubGrupo entidade)
        {
            return viewModel.TransformarEmModel(entidade);
        }

        public static SubGrupoViewModel TransformarEmViewModel(this SubGrupo entidade)
        {
            return new SubGrupoViewModel
            {
                Id = entidade.Id,
                Descricao = entidade.Descricao,
                GrupoId = entidade.GrupoId,
                GrupoViewModel = entidade.Grupo?.TransformarEmViewModel()
            };
        }
    }
}
