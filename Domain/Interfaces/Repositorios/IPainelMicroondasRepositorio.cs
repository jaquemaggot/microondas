using Dominio.Entidades;
using Dtos.Requisicao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces.Repositorios
{
    public interface IPainelMicroondasRepositorio : IRepositorio<PainelMicroondas>
    {
        Task<PainelMicroondas> Insere(PainelMicroondas painelMicroondas);
        Task<PainelMicroondas> BuscarPorId(int id);
        Task<PainelMicroondas> Atualizar(PainelMicroondas painelMicroondas);
    }
}
