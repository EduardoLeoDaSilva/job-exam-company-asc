using GestaoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoApp.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {

        private readonly ApplicationContext _context;

        public AlunoRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void AddAlunos(params Aluno[] alunos)
        {
            if (alunos.Count() > 0)
            {
                _context.Set<Aluno>().AddRange(alunos);
                
            }
            throw new Exception("Não há elementos na coleção");
        }

        public IList<Aluno> FindAll()
        {
            var alunosBd = _context.Set<Aluno>().ToList();
            if (alunosBd.Count > 0)
            {
                return alunosBd;
            }
            throw new Exception("Não há dados na base de dados");
        }

    }
}
