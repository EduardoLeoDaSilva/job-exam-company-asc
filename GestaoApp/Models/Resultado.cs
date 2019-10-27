using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoApp.Models
{
    public class Resultado
    {
        public int ResultadoId { get; set; }
        [JsonIgnore]
        public Aluno Aluno { get; set; }

        public Materia Materia { get; set; }

        public double NotaFinal { get; set; }

        public bool Aprovado { get; set; }
        [NotMapped]
        public List<Prova> Provas { get; set; }

        public Resultado()
        {

        }

        public Resultado(int resultadoId, Aluno aluno, Materia materia, double notaFinal, bool aprovado, List<Prova> provas)
        {
            ResultadoId = resultadoId;
            Aluno = aluno;
            Materia = materia;
            NotaFinal = notaFinal;
            Aprovado = aprovado;
            Provas = provas;
        }
    }
}
