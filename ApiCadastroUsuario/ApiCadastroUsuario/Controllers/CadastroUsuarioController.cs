using ApiCadastroUsuario.DTO;
using Domain.Entidades;
using Domain.Services.Interface;
using Infra.Repository.RepositoryUsuario;
using Microsoft.AspNetCore.Mvc;

namespace ApiCadastroUsuario.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CadastroUsuarioController : Controller
    {
        public readonly IServiceUsuario _servicoUsuario;
        public CadastroUsuarioController(IServiceUsuario repository)
        {
            _servicoUsuario = repository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(new { status = true });
        }


        [HttpPost]
        public IActionResult Cadastrar([FromBody] UsuarioCadastroDTO usuario)
        {

            var usuarioInsert = new Usuario(usuario.Nome, usuario.CPF, usuario.Email, usuario.DataNascimento, usuario.NumeroContado);

            _servicoUsuario.Cadastrar(usuarioInsert);

            return Json(new { mensagem = "Requisição chegou aqui blz?", dados = usuarioInsert });
        }
    }
}
