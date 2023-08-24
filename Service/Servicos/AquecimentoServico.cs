using AutoMapper;
using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Dominio.Interfaces.Servicos;
using Dominio.Modelos;
using Dtos.Requisicao;
using Dtos.Resposta;
using Infra.SqlServer.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicos.Servicos
{
    public class AquecimentoServico : IAquecimentoServico
    {
        private IPainelMicroondasRepositorio _repository;
        private readonly IMapper _mapper;
        private readonly IProgramasAquecimentoRepositorio _programas;

        public AquecimentoServico(IPainelMicroondasRepositorio repository, IMapper mapper, IProgramasAquecimentoRepositorio programas)
        {
            _repository = repository;
            _mapper = mapper;
            _programas = programas;
        }

        public async Task<AquecimentoRespostaDto> Aquecimento(AquecimentoRequisicaoDto aquecimentoRequisicaoDto) {
           
            PainelMicroondas painelMicroondas = new PainelMicroondas();

            painelMicroondas.DataInicial = DateTime.Now;
            painelMicroondas.DataFinal = painelMicroondas.DataInicial.AddSeconds(aquecimentoRequisicaoDto.Tempo);
            painelMicroondas.TempoCorrido = 0;
            painelMicroondas.Potencia = aquecimentoRequisicaoDto.Potencia;
            painelMicroondas.Cancelado = false;
            painelMicroondas.Tempo = aquecimentoRequisicaoDto.Tempo;
            painelMicroondas.StringDeAquecimento = "";
            

            var resultado = await _repository.Insere(painelMicroondas);

            var aquecimentoRespostaDto = _mapper.Map<AquecimentoRespostaDto>(resultado);

            return aquecimentoRespostaDto;
        }

        public async Task<AquecimentoRespostaDto> VerificarProcesso(int id)
        {

            var resultado = await _repository.BuscarPorId(id);

            if (resultado.Cancelado == false)
            {

                resultado.TempoCorrido++;

                if (resultado.Tempo < resultado.TempoCorrido)
                {
                    resultado.StringDeAquecimento += " Aquecimento concluído";
                }
                else
                {
                    if (!string.IsNullOrEmpty(resultado.StringDeAquecimento))
                    {
                        resultado.StringDeAquecimento += " ";
                    }
                    for (var i = 0; i < resultado.Potencia; i++)
                    {
                        resultado.StringDeAquecimento += ".";
                    }
                }

                await _repository.Atualizar(resultado);

            }
            var aquecimentoRespostaDto = _mapper.Map<AquecimentoRespostaDto>(resultado);

            aquecimentoRespostaDto.Finalizado = resultado.Tempo < resultado.TempoCorrido;

            return aquecimentoRespostaDto;

        }


        public async Task<AquecimentoRespostaDto> AdicionarSegundos(int id)
        {
            var resultado = await _repository.BuscarPorId(id);

            
            if (resultado.Cancelado)
            {
                resultado.Cancelado = false;
            }
            else
            {
                resultado.Tempo += 30;
            }
            await _repository.Atualizar(resultado);
            return _mapper.Map<AquecimentoRespostaDto>(resultado); 

        }

        public async Task<AquecimentoRespostaDto> Cancelar(int id)
        {

            var resultado = await _repository.BuscarPorId(id);

            if(resultado.Cancelado == false)
            {
                resultado.Cancelado = true;
            }
            else
            {
                resultado.TempoCorrido = resultado.Tempo;
                resultado.Cancelado = false;
            }
            await _repository.Atualizar(resultado);
            return _mapper.Map<AquecimentoRespostaDto>(resultado);

        }

        public async Task<List<ProgramasAquecimento>> BuscarProgramas()
        {
            return await _programas.BuscarTodos();
        }

        public async Task<ProgramasAquecimentoRespostaDto> InserirProgramas(ProgramasAquecimentoRequisicaoDto programasAquecimentoRequisicaoDto)
        {
            ProgramasAquecimento programasAquecimento = new ProgramasAquecimento();

            programasAquecimento.NomeDoPrograma = programasAquecimentoRequisicaoDto.NomeDoPrograma;
            programasAquecimento.Alimento = programasAquecimentoRequisicaoDto.Alimento;
            programasAquecimento.Aquecimento = programasAquecimentoRequisicaoDto.Tempo.ToString();
            programasAquecimento.Potencia = programasAquecimentoRequisicaoDto.Potencia;
            programasAquecimento.Padrao = false;
            programasAquecimento.Tempo = programasAquecimentoRequisicaoDto.Tempo;
            programasAquecimento.StringDeAquecimento = "";
            programasAquecimento.InstrucoesComplementares = programasAquecimentoRequisicaoDto.InstrucoesComplementares;

            var resultado = await _programas.InserirProgramas(programasAquecimento);

            var programasAquecimentoRespostaDto = _mapper.Map<ProgramasAquecimentoRespostaDto>(resultado);

            return programasAquecimentoRespostaDto;
        }

        public async Task<ProgramasAquecimentoRespostaDto> AtualizarProgramas(ProgramasAquecimentoRequisicaoDto programasAquecimentoRequisicaoDto, int id)
        {
            var existe = await _programas.BuscarPorId(id);
            if(existe != null && existe.Padrao == false)
            {
                ProgramasAquecimento programasAquecimento = new ProgramasAquecimento();

                programasAquecimento.NomeDoPrograma = programasAquecimentoRequisicaoDto.NomeDoPrograma;
                programasAquecimento.Alimento = programasAquecimentoRequisicaoDto.Alimento;
                programasAquecimento.Aquecimento = programasAquecimentoRequisicaoDto.Tempo.ToString();
                programasAquecimento.Potencia = programasAquecimentoRequisicaoDto.Potencia;
                programasAquecimento.Padrao = false;
                programasAquecimento.Tempo = programasAquecimentoRequisicaoDto.Tempo;
                programasAquecimento.StringDeAquecimento = "";
                programasAquecimento.InstrucoesComplementares = programasAquecimentoRequisicaoDto.InstrucoesComplementares;

                var resultado = await _programas.AtualizarProgramas(programasAquecimento);
                var programasAquecimentoRespostaDto = _mapper.Map<ProgramasAquecimentoRespostaDto>(resultado);

                return programasAquecimentoRespostaDto;
            }

            return null;
        }

        public async Task<bool> DeletarProgramas(int id)
        {
            var entity = await _programas.BuscarPorId(id);
            var result = _mapper.Map<ProgramasAquecimentoRespostaDto>(entity);
            if (result == null)
            {
                return false;
            }
            else
            {
                return await _programas.DeletarProgramas(id);
            }
        }

        public async Task<ProgramasAquecimentoRespostaDto> BuscarPorId(int id)
        {
            var entidade= await _programas.BuscarPorId(id);
            var resultado = _mapper.Map<ProgramasAquecimentoRespostaDto>(entidade);
                      
            return resultado;
            
        }
    }
}
