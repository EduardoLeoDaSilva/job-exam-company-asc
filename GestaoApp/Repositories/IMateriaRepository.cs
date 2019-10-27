using System.Collections.Generic;
using GestaoApp.Models;

namespace GestaoApp.Repositories
{
    public interface IMateriaRepository
    {
        void AddMateria(Materia materia);
        void AddRangeMaterias(params Materia[] materias);
        IList<Materia> FindAll();
        void AddOrUpdate(Materia materia);
    }
}