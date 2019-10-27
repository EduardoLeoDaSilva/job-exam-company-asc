using GestaoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoApp.Repositories
{
    public class ProvaRepository : IProvaRepository
    {
        private readonly ApplicationContext _context;

        public ProvaRepository(ApplicationContext context)
        {
            _context = context;
        }


        public void AddRangeProva(params Prova[] prova)
        {
            if (prova.Count() > 0)
            {
                _context.Set<Prova>().AddRange(prova);
                _context.SaveChanges();
            }
            throw new ArgumentNullException($"O argumento informado {nameof(prova)} é nulo");

        }

        public IList<Prova> FindAll()
        {
            var provasBd = _context.Set<Prova>().ToList();
            if (provasBd.Count > 0)
            {
                return provasBd;
            }
            throw new Exception("Não há nenhum dado na base de dados!");
        }
    }
}
