using Microsoft.AspNetCore.Mvc;
using Produtos.Entidades;
using Produtos.Entidades.Interfaces;
using Produtos.ViewModels;
using System.Linq;

namespace Produtos.Controllers
{
    [Route("api/[controller]")]
    public class SubGrupoController : Controller
    {
        private readonly ISubGrupoServico _subGrupoServico;

        public SubGrupoController(ISubGrupoServico subGrupoServico)
        {
            _subGrupoServico = subGrupoServico;
        }

        // GET api/subGrupo
        [HttpGet]
        public IActionResult ObterTodos()
        {
            return Ok(_subGrupoServico.ObterTodos().Select(subGrupo => subGrupo.TransformarEmViewModel()));
        }

        // GET api/subGrupo/5
        [HttpGet("{id:int}", Name = "ObterSubGrupoPorId")]
        public IActionResult ObterPorId(int id)
        {
            SubGrupo subGrupo = _subGrupoServico.ObterPorId(id);

            if (subGrupo == null)
            {
                return NotFound();
            }

            return Ok(subGrupo.TransformarEmViewModel());
        }

        // POST api/subGrupo
        [HttpPost]
        public IActionResult Salvar([FromBody]SubGrupoViewModel viewModel)
        {
            return Ok(_subGrupoServico.Salvar(viewModel));
        }

        // DELETE api/subGrupo/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_subGrupoServico.Excluir(id));
        }
    }
}
