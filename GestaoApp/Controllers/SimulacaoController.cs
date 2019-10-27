using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoApp.Models;
using GestaoApp.Models.ViewModels;
using GestaoApp.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace GestaoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SimulacaoController : ControllerBase
    {
        private readonly IMateriaRepository _materiaRepository;
        private readonly IProvaRepository _provaRepository;
        private readonly IAlunoRepository _alunoRepository;
        private readonly ApplicationContext _context;
        private readonly IResultadoRepository _resultadoRepository;
        public SimulacaoController(IMateriaRepository materiaRepository, IProvaRepository provaRepository, IAlunoRepository alunoRepository, ApplicationContext context, IResultadoRepository resultadoRepository)
        {
            _materiaRepository = materiaRepository;
            _provaRepository = provaRepository;
            _alunoRepository = alunoRepository;
            _context = context;
            _resultadoRepository = resultadoRepository;
        }

        [HttpPost]
        public ActionResult Simular([FromBody] QuantTurmasAlunos quantTurmasAlunos)
        {
            try
            {
               Gravar(quantTurmasAlunos.Turmas, quantTurmasAlunos.Alunos);
               var listaResultado = RealizarCalculoNotas();
                _resultadoRepository.AddResultados(listaResultado.ToArray());

                //var listaParaResponse = _context.Set<Aluno>().Include(x => x.Provas).ThenInclude(x => x.Materia).Include(x => x.Turma).Include(x => x.Resultados).Where(x => listaResultado.Where(l => l.Aluno.AlunoId ==x.AlunoId).Any()).ToList();


                var listaParaResponse= _context.Set<Turma>().Include(x => x.Alunos).ThenInclude(x => x.Provas).ThenInclude(x => x.Materia).Include(x => x.Alunos).ThenInclude(x => x.Resultados).Where(x => listaResultado.Where(t => t.Aluno.Turma.TurmaId == x.TurmaId ).Any()).ToList();

                return Content(JsonConvert.SerializeObject(listaParaResponse));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetTodasTurmasRelacionadas")]
        public ActionResult GetTodasTurmasRelNpN()
        {
            try
            {
                var listaParaResponse = _context.Set<Turma>().Include(x => x.Alunos).ThenInclude(x => x.Provas).ThenInclude(x => x.Materia).Include(x => x.Alunos).ThenInclude(x => x.Resultados).ThenInclude(x => x.Provas).ToList();

                return Content(JsonConvert.SerializeObject(listaParaResponse));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public ActionResult GetTodos()
        {
            try
            {
              var listaParaResponse =   _context.Set<Aluno>().Include(x => x.Provas).ThenInclude(x => x.Materia).Include(x => x.Turma).Where((x => x.Resultados.Count != 0 || x.Resultados != null)).ToList();
                return Ok(listaParaResponse);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        private void Gravar(int turmas, int alunos)
        {
            var materiasBd = _materiaRepository.FindAll();
             var alunosT =AlunoParaGravar(alunos, materiasBd, turmas);
            _context.Set<Aluno>().UpdateRange(alunosT);
            _context.SaveChanges();


        }

        private List<Turma> ObterTurmaParaSalvar(int turmas)
        {
            var turmaLista = new List<Turma>();
            for (int i = 0; i < turmas; i++)
            {
                var novaTurma = new Turma(0, null, "Turma");
                turmaLista.Add(novaTurma);
            }
            return turmaLista;
        }

        private List<Aluno> AlunoParaGravar(int alunos, IList<Materia> materiasBd, int turmas)
        {
            var turmaLista = ObterTurmaParaSalvar(turmas);

            Random rand = new Random();
            var alunosLista = new List<Aluno>();
            Aluno alunoASerInserido = null;
            var materiaAlunos = new List<MateriaAluno>();

            var listMateriaAlunos = new List<MateriaAluno>();

            foreach(var turma in turmaLista)
            {
                for (int j = 0; j < alunos; j++)
                {
                    alunoASerInserido = new Aluno(0, $"Aluno - {j}", null, null, null);
                    var aluno = alunoASerInserido;
                    aluno.Provas = new List<Prova>();

                    foreach (var materia in materiasBd)
                    {

                        
                        var p1 = new Prova(0, $"{materia.Nome} - Prova 1", materia.Peso1, materia, null, rand.Next(0, 10));
                        var p2 = new Prova(0, $"{materia.Nome} - Prova 2", materia.Peso2, materia, null, rand.Next(0, 10));
                        var p3 = new Prova(0, $"{materia.Nome} - Prova 3", materia.Peso3, materia, null, rand.Next(0, 10));
                        aluno.Provas.Add(p1);
                        aluno.Provas.Add(p2);
                        aluno.Provas.Add(p3);

                        aluno.MateriaAluno = new List<MateriaAluno>();
                        aluno.MateriaAluno.Add(new MateriaAluno(materia.MateriaId, 0, aluno, null));
                        //materiaAlunos.Add(new MateriaAluno(0, 0, aluno, null));

                        //materia.MateriaAluno = materiaAlunos;
                        //_materiaRepository.AddOrUpdate(materia);
                        

                    }
                    alunosLista.Add(aluno);

                    aluno.Turma = turma;

                }
            }
            return alunosLista;




        }

        private List<Resultado> RealizarCalculoNotas()
        {
            Random rand = new Random();
            var listaIsAprovadoPeriodo = new List<bool>();
            var listaResultado = new List<Resultado>();
            var dadosRelacionadosBd = _context.Set<Aluno>().Include(x => x.Provas).ThenInclude(x => x.Materia).Include(x => x.Turma).Where( x=> x.Resultados.Count == 0 || x.Resultados == null).ToList();
            var materias = _context.Set<Materia>().ToList();
            foreach (var aluno in dadosRelacionadosBd)
            {
                foreach(var materia in materias)
                {
                    double media = 0;
                    bool aprovado = false;

                    ///Logica
                    var listaProvasPorMateria=  aluno.Provas.Where(x => x.Materia == materia && x.Aluno == aluno).ToList();
                    var notasPesosProvas = listaProvasPorMateria.Select(x => new { x.Nota, x.Peso}).ToList();

                    var somaDasNotasXPesos = notasPesosProvas.Select(x =>  x.Nota * x.Peso ).Sum();
                    var somaDosPesos = notasPesosProvas.Select(x => x.Peso).Sum();

                    media = somaDasNotasXPesos / somaDosPesos;


                    aprovado = media >= 6 ? true : false;
                    if(media > 4 && media < 6)
                    {
                        var prova = new Prova(0, "Prova Final", 10, materia, null, rand.Next(0, 10));
                        aluno.Provas.Add(prova);
                        _context.Set<Prova>().Update(prova);
                        _context.SaveChanges();
                        listaProvasPorMateria = aluno.Provas.Where(x => x.Materia == materia && x.Aluno == aluno).ToList();
                        media = media + prova.Nota;
                        aprovado = media >=6 ? true: false;
                    }

                     if(aprovado == true)listaIsAprovadoPeriodo.Add(aprovado);
                    var resultado = new Resultado(0, aluno, materia, double.Parse(media.ToString("F2")), aprovado, listaProvasPorMateria); ;
                    resultado.Provas = listaProvasPorMateria;
                    listaResultado.Add(resultado);
                }
                    var porcentagemDeAprovacaoPeriodo = ((60.0 * materias.Count()) / 100.0);
                    aluno.AprovadoPeriodo = listaIsAprovadoPeriodo.Count >= porcentagemDeAprovacaoPeriodo ? true : false;
                    listaIsAprovadoPeriodo.Clear();
            }
            return listaResultado;

        }
    }
}