using Produtos.Entidades.Mensagens;
using Produtos.Infraestrutura.Extensions;
using Produtos.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Produtos.Entidades.Regras
{
    public class SubGrupoRegras
    {
        public static IEnumerable<string> ValidarParaSalvar(SubGrupoViewModel viewModel, IQueryable<SubGrupo> subGrupos)
        {
            if (string.IsNullOrWhiteSpace(viewModel.Descricao))
                yield return Mensagem.ParametroObrigatorio.Formatar(Termo.Descricao);

            if (PossuiSubGrupoPorDescricao(subGrupos, viewModel.Id, viewModel.Descricao))
                yield return Mensagem.EntidadeDuplicada.Formatar(Termo.Descricao);
        }

        public static IEnumerable<string> ValidarParaExcluir(SubGrupo entidade)
        {
            if (entidade == null)
                yield return Mensagem.EntidadeNaoEncontrada.Formatar(Termo.SubGrupo);
        }

        private static bool PossuiSubGrupoPorDescricao(IQueryable<SubGrupo> subGrupos, int id, string descricao)
        {
            return subGrupos.Any(subGrupo =>
                    (id == 0 || subGrupo.Id != id) &&
                    subGrupo.Descricao.ToLower().Equals(descricao.ToLower()));
        }
    }
}
