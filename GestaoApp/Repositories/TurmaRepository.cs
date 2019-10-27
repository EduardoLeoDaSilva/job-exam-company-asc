using GestaoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoApp.Repositories
{
    public class TurmaRepository : ITurmaRepository
    {
        private readonly ApplicationContext _context;

        public TurmaRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void AddTurmas(params Turma[] turmas)
        {
            if (turmas.Count() > 0)
            {
                _context.Set<Turma>().AddRange(turmas);
                _context.SaveChanges();
            }
            throw new Exception("Não há elementos na coleção");
        }

        public IList<Turma> FindAll()
        {
            var turmasBd = _context.Set<Turma>().ToList();
            if (turmasBd.Count > 0)
            {
                return turmasBd;
            }
            throw new Exception("Não há dados na base de dados");
        }
    }
}
