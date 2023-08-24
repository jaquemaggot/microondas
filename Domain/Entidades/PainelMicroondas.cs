using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class PainelMicroondas : EntidadeBase
    {         
        public int Tempo { get; set; }
        public int Potencia { get; set; }
        public bool Cancelado { get; set;}
        public string StringDeAquecimento { get; set; }
        public DateTime DataFinal { get; set; }
        public DateTime DataInicial { get; set; }
        public int TempoCorrido { get; set; }
    }
}
