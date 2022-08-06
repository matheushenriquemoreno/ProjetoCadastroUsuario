using ApiCadastroUsuario.DTO;
using Domain.Entidades;
using Infra.Repository.RepositoryUsuario;
using Microsoft.AspNetCore.Mvc;

namespace ApiCadastroUsuario.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CadastroUsuarioController : Controller
    {
        public readonly IReporitoryUsuario reporitoryUsuario;
        public CadastroUsuarioController(IReporitoryUsuario repository)
        {
            reporitoryUsuario = repository;
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

            reporitoryUsuario.Adiciona(usuarioInsert);

            return Json(new { mensagem = "Requisição chegou aqui blz?", dados = usuarioInsert });
        }
    }
}
