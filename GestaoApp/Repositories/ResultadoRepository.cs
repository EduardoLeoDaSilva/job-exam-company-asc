using GestaoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoApp.Repositories
{
    public class ResultadoRepository : IResultadoRepository
    {
        private readonly ApplicationContext _context;

        public ResultadoRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void AddResultados(params Resultado[] resultados)
        {
            if (resultados.Count() > 0)
            {
                _context.Set<Resultado>().AddRange(resultados);
                _context.SaveChanges();
                return;
            }
            throw new Exception("Não há elementos na coleção");
        }

        public IList<Resultado> FindAll()
        {
            var resultadosBd = _context.Set<Resultado>().ToList();
            if (resultadosBd.Count > 0)
            {
                return resultadosBd;
            }
            throw new Exception("Não há dados na base de dados");
        }
    }
}
