using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Resposta
{
    public  class AquecimentoRespostaDto
    {
        public int Id { get; set; }
        public int Tempo { get; set; }
        public int Potencia { get; set; }
        public bool Cancelado { get; set; }
        public bool Finalizado { get; set; }
        public string StringDeAquecimento { get; set; }
    }
}
