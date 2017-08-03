using Produtos.Entidades.Mensagens;
using Produtos.Infraestrutura.Extensions;
using Produtos.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Produtos.Entidades.Regras
{
    public class GrupoRegras
    {
        public static IEnumerable<string> ValidarParaSalvar(GrupoViewModel viewModel, IQueryable<Grupo> grupos)
        {
            if (string.IsNullOrWhiteSpace(viewModel.Descricao))
                yield return Mensagem.ParametroObrigatorio.Formatar(Termo.Descricao);

            if (PossuiGrupoPorDescricao(grupos, viewModel.Id, viewModel.Descricao))
                yield return Mensagem.EntidadeDuplicada.Formatar(Termo.Descricao);
        }

        public static IEnumerable<string> ValidarParaExcluir(Grupo entidade)
        {
            if (entidade == null)
                yield return Mensagem.EntidadeNaoEncontrada.Formatar(Termo.Grupo);
        }

        private static bool PossuiGrupoPorDescricao(IQueryable<Grupo> grupos, int id, string descricao)
        {
            return grupos.Any(grupo =>
                    (id == 0 || grupo.Id != id) &&
                    grupo.Descricao.ToLower().Equals(descricao.ToLower()));
        }
    }
}
