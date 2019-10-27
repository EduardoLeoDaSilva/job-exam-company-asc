using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoApp.Models
{
    public class MateriaAluno
    {
        public int MateriaId { get; set; }
        public int AlunoId { get; set; }
        [JsonIgnore]
        public Aluno Aluno { get; set; }
        [JsonIgnore]
        public Materia Materia { get; set; }

        public MateriaAluno()
        {

        }

        public MateriaAluno(int materiaId, int alunoId, Aluno aluno, Materia materia)
        {
            MateriaId = materiaId;
            AlunoId = alunoId;
            Aluno = aluno;
            Materia = materia;
        }
    }
}
