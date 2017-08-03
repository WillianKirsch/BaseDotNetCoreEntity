using Microsoft.AspNetCore.Mvc;
using Produtos.Entidades;
using Produtos.Entidades.Interfaces;
using Produtos.ViewModels;
using System.Linq;

namespace Produtos.Controllers
{
    [Route("api/[controller]")]
    public class GrupoController : Controller
    {
        private readonly IGrupoServico _grupoServico;

        public GrupoController(IGrupoServico grupoServico)
        {
            _grupoServico = grupoServico;
        }

        // GET api/grupo
        [HttpGet]
        public IActionResult ObterTodos()
        {
            return Ok(_grupoServico.ObterTodos().Select(grupo => grupo.TransformarEmViewModel()));
        }

        // GET api/grupo/5
        [HttpGet("{id:int}", Name = "ObterGrupoPorId")]
        public IActionResult ObterPorId(int id)
        {
            Grupo grupo = _grupoServico.ObterPorId(id);

            if (grupo == null)
            {
                return NotFound();
            }

            return Ok(grupo.TransformarEmViewModel());
        }

        // POST api/grupo
        [HttpPost]
        public IActionResult Salvar([FromBody]GrupoViewModel viewModel)
        {
            return Ok(_grupoServico.Salvar(viewModel));
        }

        // DELETE api/grupo/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_grupoServico.Excluir(id));
        }
    }
}
