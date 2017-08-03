using Produtos.Entidades;

namespace Produtos.ViewModels
{
    public class GrupoViewModel : ViewModel
    {
        public string Descricao { get; set; }
    }

    public static class GrupoExtension
    {
        public static Grupo TransformarEmModel(this GrupoViewModel viewModel, Grupo entidade)
        {
            entidade.Id = viewModel.Id;
            entidade.Descricao = viewModel.Descricao;

            return entidade;
        }

        public static Grupo TransformarViewEmModel(GrupoViewModel viewModel, Grupo entidade)
        {
            return viewModel.TransformarEmModel(entidade);
        }

        public static GrupoViewModel TransformarEmViewModel(this Grupo entidade)
        {
            return new GrupoViewModel
            {
                Id = entidade.Id,
                Descricao = entidade.Descricao
            };
        }
    }
}
