using GestaoApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoApp.Repositories
{
    public class MateriaRepository : IMateriaRepository
    {
        private readonly ApplicationContext _context;

        public MateriaRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void AddMateria(Materia materia)
        {
            if (materia != null)
            {
               
                _context.Set<Materia>().Add(materia);
                _context.SaveChanges();
                return;
            }
            throw new ArgumentException($"Argumento informado é nulo {materia}");
        }

        public void AddRangeMaterias(params Materia[] materias)
        {
            if (materias.Count() > 0)
            {
                _context.Set<Materia>().AddRange(materias);
                _context.SaveChanges();
                return;
            }
            throw new Exception("Não há elementos na coleção do argumento informado");
        }

        public IList<Materia> FindAll()
        {
            
            var materiasBd = _context.Set<Materia>().AsNoTracking().ToList();

            if (materiasBd.Count > 0)
            {
                return materiasBd;
            }
            throw new Exception("Não há dados no banco");
        }


            public  void AddOrUpdate(Materia materia)
            {
                
                    var exists = _context.Set<Materia>().AsNoTracking().Any(x => x.MateriaId == materia.MateriaId);
                    if (exists)
                    {
                    _context.Set<Materia>().Update(materia);
                    }
                _context.Set<Materia>().Add(materia);
                
            }
        
    }
}
