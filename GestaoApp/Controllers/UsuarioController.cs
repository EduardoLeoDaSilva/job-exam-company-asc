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
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;


        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost]
        public ActionResult Logar([FromBody]Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   var usuarioBd = _usuarioRepository.VerificarUsuario(usuario);
                    return Ok(usuario);
                }
                return Content("Estado do modelo inválido");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("cadastrar")]
        public ActionResult Cadastrar([FromBody] Usuario usuario)
        {
            var msg = "";
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepository.AddUser(usuario);
                     msg = "Usuário Cadastrado";
                    return Content(JsonConvert.SerializeObject(msg));

                }
               msg = "Usuário Cadastrado";

                return Content(JsonConvert.SerializeObject(msg));
            }
            catch (Exception e)
            {
                if(e.InnerException.HResult == -2146232060)
                {
                    return BadRequest(JsonConvert.SerializeObject("Email já cadastrado!"));

                }
                return BadRequest(JsonConvert.SerializeObject("Erro"));
            }
        }
    }
}