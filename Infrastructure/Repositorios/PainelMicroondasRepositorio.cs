using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Dtos.Requisicao;
using Infraestrutura.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Repositorios
{
    public class PainelMicroondasRepositorio : BaseRepositorio<PainelMicroondas>, IPainelMicroondasRepositorio
    {
        public PainelMicroondasRepositorio(MicroondasContexto context) : base(context)
        {
        }

        public async Task<PainelMicroondas> Insere(PainelMicroondas painelMicroondas)
        {
            try
            {
                _dataset.Add(painelMicroondas);
                await _context.SaveChangesAsync();
                return painelMicroondas;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<PainelMicroondas> BuscarPorId(int id)
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

        public async Task<PainelMicroondas> Atualizar(PainelMicroondas painelMicroondas)
        {
           try
           {
                var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(painelMicroondas.Id));
                if (result == null)
                    return null;

                _context.Entry(result).CurrentValues.SetValues(painelMicroondas);
                await _context.SaveChangesAsync();

            }
           catch(Exception ex)
           {
                throw ex;
           }
           return painelMicroondas;

        }
    }
}
