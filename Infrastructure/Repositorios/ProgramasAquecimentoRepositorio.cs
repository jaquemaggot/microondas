using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Infraestrutura.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Repositorios
{
    public class ProgramasAquecimentoRepositorio : BaseRepositorio<ProgramasAquecimento>, IProgramasAquecimentoRepositorio
    {
        public ProgramasAquecimentoRepositorio(MicroondasContexto context) : base(context)
        {
        }

        public async Task<ProgramasAquecimento> AtualizarProgramas(ProgramasAquecimento programasAquecimento)
        {
            try
            {
                var resultado = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(programasAquecimento.Id));
                if (resultado == null)
                    return null;

                _context.Entry(resultado).CurrentValues.SetValues(programasAquecimento);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return programasAquecimento;
        }

        public async Task<ProgramasAquecimento> BuscarPorId(int id)
        {
            try
            {
                return await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<ProgramasAquecimento>> BuscarTodos()
        {
            try
            {
                return await _dataset.ToListAsync();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> DeletarProgramas(int id)
        {
            try
            {
                var resultado = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));

                if (resultado == null)
                {
                    return false;
                }
                    
                _dataset.Remove(resultado);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ProgramasAquecimento> InserirProgramas(ProgramasAquecimento programasAquecimento)
        {
            try
            {
                _dataset.Add(programasAquecimento);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return programasAquecimento;
        }
    }
}
