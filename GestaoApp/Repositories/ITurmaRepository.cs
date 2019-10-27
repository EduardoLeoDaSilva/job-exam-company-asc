using System.Collections.Generic;
using GestaoApp.Models;

namespace GestaoApp.Repositories
{
    public interface ITurmaRepository
    {
        void AddTurmas(params Turma[] turmas);
        IList<Turma> FindAll();
    }
}