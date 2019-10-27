using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoApp.Models
{
    public class Prova
    {
        public int ProvaId { get; set; }
        public string Nome { get; set; }
        public double Peso { get; set; }

        public double Nota { get; set; }
        public Materia Materia { get; set; }

        [JsonIgnore]
        public Aluno Aluno { get; set; }

        public Prova()
        {

        }
        public Prova(int provaId, string nome, double peso, Materia materia, Aluno aluno, double nota)
        {
            ProvaId = provaId;
            Nome = nome;
            Peso = peso;
            Nota = nota;
            Materia = materia;
            Aluno = aluno;
        }
    }
}
