using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces.Repositorios
{
    public interface IProgramasAquecimentoRepositorio : IRepositorio<ProgramasAquecimento>
    {
        Task<List<ProgramasAquecimento>> BuscarTodos();
        Task<ProgramasAquecimento> InserirProgramas(ProgramasAquecimento programasAquecimento);
        Task<ProgramasAquecimento> AtualizarProgramas(ProgramasAquecimento programasAquecimento);
        Task<bool> DeletarProgramas(int id);
        Task<ProgramasAquecimento> BuscarPorId(int id);

       
    }
}
