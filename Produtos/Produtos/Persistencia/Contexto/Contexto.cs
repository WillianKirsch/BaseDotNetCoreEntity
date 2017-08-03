using Microsoft.EntityFrameworkCore;
using Produtos.Entidades;
using Produtos.Entidades.Mensagens;
using Produtos.Persistencia.Mapeamentos;
using System;
using System.Collections.Generic;

namespace Produtos.Persistencia.Contexto
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new ProdutoMap(modelBuilder.Entity<Produto>());
            new GrupoMap(modelBuilder.Entity<Grupo>());
            new SubGrupoMap(modelBuilder.Entity<SubGrupo>());
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<SubGrupo> SubGrupos { get; set; }


        public TEntidade Incluir<TEntidade>(TEntidade entidade) where TEntidade : Entidade
        {
            this.Set<TEntidade>().Add(entidade);
            return entidade;
        }

        public IEnumerable<TEntidade> IncluirVarios<TEntidade>(IEnumerable<TEntidade> entidades) where TEntidade : Entidade
        {
            this.Set<TEntidade>().AddRange(entidades);
            return entidades;
        }

        public TEntidade Alterar<TEntidade>(TEntidade entidade) where TEntidade : Entidade
        {
            this.Entry<TEntidade>(entidade).State = EntityState.Modified;
            return entidade;
        }

        public TEntidade Excluir<TEntidade>(TEntidade entidade) where TEntidade : Entidade
        {
            this.Set<TEntidade>().Remove(entidade);
            return entidade;
        }

        public TEntidade Desanexar<TEntidade>(TEntidade entidade) where TEntidade : Entidade
        {
            this.Entry<TEntidade>(entidade).State = EntityState.Detached;
            return entidade;
        }

        public T ObterEntidadePorId<T>(int id) where T : Entidade
        {
            T entidade = Set<T>().Find(id);

            if (entidade == null)
                throw new Exception(Mensagem.EntidadeNaoEncontrada);

            return entidade;
        }
    }
}