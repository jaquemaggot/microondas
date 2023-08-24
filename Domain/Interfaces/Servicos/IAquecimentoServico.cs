using Dominio.Entidades;
using Dtos.Requisicao;
using Dtos.Resposta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces.Servicos
{
    public interface IAquecimentoServico
    {
        Task<AquecimentoRespostaDto> AdicionarSegundos(int id);
        public Task<AquecimentoRespostaDto> Aquecimento(AquecimentoRequisicaoDto aquecimentoRequisicaoDto);
        Task<AquecimentoRespostaDto> Cancelar(int id);
        public Task<AquecimentoRespostaDto> VerificarProcesso(int id);

        public Task<List<ProgramasAquecimento>> BuscarProgramas();
        Task<ProgramasAquecimentoRespostaDto> InserirProgramas(ProgramasAquecimentoRequisicaoDto programasAquecimentoRequisicaoDto);
        Task<ProgramasAquecimentoRespostaDto> AtualizarProgramas(ProgramasAquecimentoRequisicaoDto programasAquecimentoRequisicaoDto, int id);
        Task<bool> DeletarProgramas(int id);
        Task<ProgramasAquecimentoRespostaDto> BuscarPorId(int id);

    }
}
