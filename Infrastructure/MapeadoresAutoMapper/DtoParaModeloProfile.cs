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
    public class DtoParaModeloProfile : Profile
    {
        public DtoParaModeloProfile()
        {
            CreateMap<PainelMicroondasModelo, AquecimentoRequisicaoDto>().ReverseMap();
            CreateMap<PainelMicroondasModelo, AquecimentoRespostaDto>().ReverseMap();

        }
    }
}
