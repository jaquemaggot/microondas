using AutoMapper;
using Dominio.Entidades;
using Dominio.Modelos;
using Dtos.Requisicao;
using Dtos.Resposta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.MapeadoresAutoMapper
{
    public class EntidadeParaDtoProfile : Profile
    {
        public EntidadeParaDtoProfile()
        {
            CreateMap<AquecimentoRequisicaoDto, PainelMicroondas>().ReverseMap();
            CreateMap<AquecimentoRespostaDto, PainelMicroondas>().ReverseMap();
            CreateMap<ProgramasAquecimentoRespostaDto, ProgramasAquecimento>().ReverseMap();
            CreateMap<ProgramasAquecimentoRequisicaoDto, ProgramasAquecimento>().ReverseMap();
        }
    }
}
