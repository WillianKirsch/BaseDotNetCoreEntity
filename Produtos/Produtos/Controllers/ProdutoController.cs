using Microsoft.AspNetCore.Mvc;
using Produtos.Entidades;
using Produtos.Entidades.Interfaces;
using Produtos.ViewModels;
using System.Linq;

namespace Produtos.Controllers
{
    [Route("api/[controller]")]
    public class ProdutoController : Controller
    {
        private readonly IProdutoServico _produtoServico;

        public ProdutoController(IProdutoServico produtoServico)
        {
            _produtoServico = produtoServico;
        }

        // GET api/produto
        [HttpGet]
        public IActionResult ObterTodos()
        {
            return Ok(_produtoServico.ObterTodos().Select(produto => produto.TransformarEmViewModel()));
        }

        // GET api/produto/5
        [HttpGet("{id:int}", Name = "ObterProdutoPorId")]
        public IActionResult ObterPorId(int id)
        {
            Produto produto = _produtoServico.ObterPorId(id);

            if (produto == null)
            {
                return NotFound();
            }

            return Ok(produto.TransformarEmViewModel());
        }

        // POST api/produto
        [HttpPost]
        public IActionResult Salvar([FromBody]ProdutoViewModel viewModel)
        {
            return Ok(_produtoServico.Salvar(viewModel));
        }

        // DELETE api/produto/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_produtoServico.Excluir(id));
        }
    }
}
