using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Requisicao
{
    public class ProgramasAquecimentoRequisicaoDto
    {
        public string NomeDoPrograma { get; set; }
        public string Alimento { get; set; }
        public string Aquecimento { get; set; }
        public int Tempo { get; set; }
        public int Potencia { get; set; }
        public string StringDeAquecimento { get; set; }
        public string InstrucoesComplementares { get; set; }
        public bool Padrao { get; set; }
    }
}
