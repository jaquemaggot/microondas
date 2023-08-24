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
    public class BaseRepositorio<T> : IRepositorio<T> where T : EntidadeBase
    {
        protected readonly MicroondasContexto _context;
        protected DbSet<T> _dataset;

        public BaseRepositorio(MicroondasContexto context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }

    }
}
