using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoApp.Models
{
    public class Aluno
    {
        public int AlunoId { get; set; }
        public string Nome { get; set; }

        public IList<MateriaAluno> MateriaAluno { get; set; }


        [JsonIgnore]
        public Turma Turma { get; set; }

        public IList<Prova> Provas { get; set; }

        public IList<Resultado> Resultados { get; set; }

        public bool AprovadoPeriodo { get; set; }

        public Aluno()
        {

        }

        public Aluno(int alunoId, string nome, IList<MateriaAluno> materiaAluno, Turma turma, IList<Prova> provas)
        {
            AlunoId = alunoId;
            Nome = nome;
            MateriaAluno = materiaAluno;
            Turma = turma;
            Provas = provas;
        }
    }
}
