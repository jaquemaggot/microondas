using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Dominio.Interfaces.Servicos;
using Dtos.Requisicao;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AquecimentoController : ControllerBase
    {
        public IAquecimentoServico _servico;

        public AquecimentoController(IAquecimentoServico servico)
        {
            _servico = servico;
        }

        [HttpPost]
        public async Task<ActionResult> Aquecimento([FromBody] AquecimentoRequisicaoDto aquecimentoRequisicaoDto)
        {
            var resultado = await _servico.Aquecimento(aquecimentoRequisicaoDto);
            return Ok(resultado);
        }

        [HttpGet]
        [Route("{id}", Name = "PainelMicroondasId")]
        public async Task<ActionResult> VerificarProcesso(int id)
        {
            var resultado = await _servico.VerificarProcesso(id);
            return Ok(resultado);
        }

        [HttpPost]
        [Route("{id}")]
        public async Task<ActionResult> AdicionarSegundos(int id)
        {
            var resultado = await _servico.AdicionarSegundos(id);
            return Ok(resultado);
        }

        [HttpPost]
        [Route("cancelar/{id}")]
        public async Task<ActionResult> Cancelar(int id)
        {
            var resultado = await _servico.Cancelar(id);
            return Ok(resultado);
        }

        [HttpGet("programas")]
        public async Task<ActionResult> BuscarTodos()
        {
            var programas = await _servico.BuscarProgramas();
            return Ok(programas);
        }

        [HttpPost]
        [Route("programa")]
        public async Task<ActionResult> InserirProgramas(ProgramasAquecimentoRequisicaoDto programasAquecimentoRequisicaoDto)
        {
            var resultado = await _servico.InserirProgramas(programasAquecimentoRequisicaoDto);
            return Ok(resultado);
        }

        [HttpGet]
        [Route("programa/{id}")]
        public async Task<ActionResult> BuscarPorId(int id)
        {
            var resultado = await _servico.BuscarPorId(id);
            return Ok(resultado);
        }

        [HttpDelete]
        [Route("programa/{id}")]
        public async Task<ActionResult> DeletarProgramas(int id)
        {
            var resultado = await _servico.DeletarProgramas(id);
            return Ok(resultado);
        }

        [HttpPut]
        [Route("programa/{id}")]
        public async Task<ActionResult> AtualizarProgramas(ProgramasAquecimentoRequisicaoDto programasAquecimentoRequisicaoDto, int id)
        {
            var resultado = await _servico.AtualizarProgramas(programasAquecimentoRequisicaoDto, id);
            return Ok(resultado);
        }


    }
}
