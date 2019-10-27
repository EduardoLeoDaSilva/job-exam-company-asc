using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoApp.Models
{
    public class Materia
    {
        public int MateriaId { get; set; }
        public string Nome { get; set; }

        [JsonIgnore]
        public IList<Prova> Provas { get; set; }


        public IList<MateriaAluno> MateriaAluno { get; set; }



        public int Peso1 { get; set; }
        public int Peso2 { get; set; }
        public int Peso3 { get; set; }

        public Materia()
        {

        }

        public Materia(int materiaId, string nome, IList<Prova> provas, IList<MateriaAluno> materiaAluno, int peso1, int peso2, int peso3)
        {
            MateriaId = materiaId;
            Nome = nome;
            Provas = provas;
            MateriaAluno = materiaAluno;
            Peso1 = peso1;
            Peso2 = peso2;
            Peso3 = peso3;
        }
    }
}
