using AutoMapper;
using Dominio.Entidades;
using Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.MapeadoresAutoMapper
{
    public class ModeloParaEntidadeProfile : Profile
    {
        public ModeloParaEntidadeProfile()
        {
            CreateMap<PainelMicroondas, PainelMicroondasModelo>().ReverseMap();
        }
        
    }
}
