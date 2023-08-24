using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Modelos
{
    public class PainelMicroondasModelo
    {

        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private int _tempo;
        public int Tempo
        {
            get { return _tempo; }
            set { _tempo = value; }
        }

        private int _potencia;
        public int Potencia
        {
            get { return _potencia; }
            set { _potencia = value; }
        }

        private int _cancelado;
        public int Cancelado
        {
            get { return _cancelado; }
            set { _cancelado = value; }
        }

        private DateTime _dataInicial;
        public DateTime DataInicial
        {
            get { return _dataInicial; }
            set { _dataInicial = value; }
        }

        private DateTime _dataFinal;
        public DateTime DataFinal
        {
            get { return _dataFinal; }
            set { _dataFinal = value; }
        }

    }
}
