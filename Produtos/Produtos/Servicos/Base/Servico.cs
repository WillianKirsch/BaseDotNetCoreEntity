using Microsoft.EntityFrameworkCore;
using Produtos.Entidades;
using Produtos.Infraestrutura.Exceptions;
using Produtos.Infraestrutura.Extensions;
using Produtos.Persistencia.Contexto;
using Produtos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Produtos.Servicos
{
    public abstract class Servico<TEntidade, TViewModel>
        where TEntidade : Entidade
        where TViewModel : ViewModel
    {
        private readonly Contexto _contexto;
        protected Contexto Contexto { get { return _contexto; } }

        public Servico(Contexto contexto)
        {
            _contexto = contexto;
        }

        public virtual TEntidade ObterPorId(int id)
        {
            return this.Contexto.ObterEntidadePorId<TEntidade>(id);
        }

        public virtual IQueryable<TEntidade> ObterTodos()
        {
            return this.Contexto.Set<TEntidade>();
        }

        public virtual TEntidade Excluir(
            int id,
            Func<TEntidade, IEnumerable<string>> metodoParaValidarExclusao)
        {
            TEntidade entidade = ObterEntidadeParaExcluir(id);
            return Excluir(entidade, metodoParaValidarExclusao);
        }

        public virtual TEntidade Excluir(
            TEntidade entidade,
            Func<TEntidade, IEnumerable<string>> metodoParaValidarExclusao)
        {
            string[] erros = metodoParaValidarExclusao(entidade).ToArray();

            if (erros.Length > 0)
                throw new ValidationException(erros);

            return ExecutarExclusao(entidade);
        }

        public virtual TEntidade Salvar(
            TViewModel viewModel,
            Func<IEnumerable<string>> metodoParaValidarViewModel,
            Func<TViewModel, TEntidade, TEntidade> metodoParaTransformarViewModelEmModel)
        {
            string[] erros = metodoParaValidarViewModel().ToArray();

            if (erros.Length > 0)
                throw new ValidationException(erros);

            return ExecutarSalvar(viewModel, metodoParaTransformarViewModelEmModel);
        }

        private TEntidade ExecutarSalvar(
            TViewModel viewModel,
            Func<TViewModel, TEntidade, TEntidade> metodoParaTransformarViewModelEmModel)
        {
            return viewModel.Id > 0 ?
                Alterar(viewModel, metodoParaTransformarViewModelEmModel)
                : Incluir(viewModel, metodoParaTransformarViewModelEmModel);
        }

        private TEntidade Incluir(TViewModel viewModel,
            Func<TViewModel, TEntidade, TEntidade> metodoParaTransformarViewModelEmModel)
        {
            TEntidade entidade = Activator.CreateInstance<TEntidade>();
            entidade = metodoParaTransformarViewModelEmModel(viewModel, entidade);
            return ExecutarIncluir(entidade);
        }

        private TEntidade Alterar(
            TViewModel viewModel,
            Func<TViewModel, TEntidade, TEntidade> metodoParaTransformarViewModelEmModel)
        {
            TEntidade entidadeParaAlterar = ObterEntidadeParaAlterar(viewModel.Id);
            TEntidade entidadeOriginal = ClonarEntidadeParaAlterar(entidadeParaAlterar);

            return VerificaSeEntidadeFoiAlteradaEExecutaAlteracao(metodoParaTransformarViewModelEmModel(viewModel, entidadeParaAlterar), entidadeOriginal);
        }

        private TEntidade VerificaSeEntidadeFoiAlteradaEExecutaAlteracao(TEntidade entidade, TEntidade entidadeOriginal)
        {
            bool foiAlterada =
                Contexto.Entry<TEntidade>(entidade).State == EntityState.Modified;

            return foiAlterada ? ExecutarAlteracao(entidade, entidadeOriginal)
                                    : entidade;
        }

        private TEntidade ExecutarAlteracao(TEntidade entidade, TEntidade entidadeOriginal)
        {
            Contexto.Alterar<TEntidade>(entidade);
            Contexto.SaveChanges();
            return entidade;
        }

        private TEntidade ExecutarExclusao(TEntidade entidadeParaExcluir)
        {
            Contexto.Excluir<TEntidade>(entidadeParaExcluir);
            Contexto.SaveChanges();
            return entidadeParaExcluir;
        }

        protected virtual TEntidade ObterEntidadeParaAlterar(int id)
        {
            return Contexto.ObterEntidadePorId<TEntidade>(id);
        }

        protected virtual TEntidade ClonarEntidadeParaAlterar(TEntidade entidade)
        {
            return entidade.Clonar();
        }

        protected virtual TEntidade ObterEntidadeParaExcluir(int id)
        {
            return Contexto.ObterEntidadePorId<TEntidade>(id);
        }

        protected TEntidade ExecutarIncluir(TEntidade entidade)
        {
            Contexto.Incluir<TEntidade>(entidade);
            Contexto.SaveChanges();
            return entidade;
        }

        protected IEnumerable<TEntidade> ExecutarIncluirVarios(IEnumerable<TEntidade> entidades)
        {
            Contexto.IncluirVarios<TEntidade>(entidades);
            Contexto.SaveChanges();
            return entidades;
        }
    }
}
