using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoApp.Models;
using GestaoApp.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GestaoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriaController : ControllerBase
    {
        private readonly IMateriaRepository _materiaRepository;
        public MateriaController(IMateriaRepository materiaRepository)
        {
            _materiaRepository = materiaRepository;
        }

        [HttpPost]
        public ActionResult Cadastrar([FromBody] Materia materia)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _materiaRepository.AddMateria(materia);
                    var materias = _materiaRepository.FindAll();
                    if(materias.Count > 0)
                    {
                        return Ok(JsonConvert.SerializeObject(materias));
                    }
                    return Ok();
                }
                return BadRequest("O estado do modelo não é valido");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


        [HttpGet]
        public ActionResult ObterTodos()
        {
            try
            {
                var materias = _materiaRepository.FindAll();
                if(materias.Count > 0)
                {
                    return Ok(JsonConvert.SerializeObject(materias));
                }
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

    }
}