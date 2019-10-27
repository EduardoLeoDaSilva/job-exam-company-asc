using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoApp.Models
{
    public class Turma
    {
        public int TurmaId { get; set; }

        public IList<Aluno> Alunos { get; set; }

        public string Nome { get; set; }
        public Turma()
        {

        }

        public Turma(int turmaId, IList<Aluno> alunos, string nome)
        {
            TurmaId = turmaId;
            Alunos = alunos;
            Nome = nome;
        }
    }
}
