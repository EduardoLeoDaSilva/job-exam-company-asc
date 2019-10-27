using System.Collections.Generic;
using GestaoApp.Models;

namespace GestaoApp.Repositories
{
    public interface IAlunoRepository
    {
        void AddAlunos(params Aluno[] alunos);
        IList<Aluno> FindAll();
    }
}