using Exoapi.Interfaces;
using Exoapi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exoapi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]

    [Authorize(Roles = "2, 1")]

    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioRepository _iFuncionarioRepository;

        public FuncionarioController(IFuncionarioRepository funcionarioRepository)
        {
            _iFuncionarioRepository = funcionarioRepository;
        }


        [Authorize(Roles = "1")]
        [HttpGet]
        
        public IActionResult Listar()
        {
            try
            {
                return Ok(_iFuncionarioRepository.Listar());
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);

            }
        }

        [Authorize(Roles = "2")]
        [HttpGet("{IDFuncionario}")]
        public IActionResult BuscarId(int IDFuncionario)
        {
            try
            {
                Funcionario funcionario = _iFuncionarioRepository.BuscarId(IDFuncionario);

                if (funcionario == null)
                {
                    return NotFound();
                }
                return Ok(funcionario);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        [Authorize(Roles = "2")]
        [HttpPost]

        public IActionResult Cadastrar(Funcionario funcionario)
        {
            try
            {
                _iFuncionarioRepository.Cadastrar(funcionario);
                return StatusCode(201);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        [Authorize(Roles = "2")]
        [HttpPut("{IDFuncionario}")]

        public IActionResult Alterar(int IDFuncionario, Funcionario funcionario)
        {
            try
            {

                Funcionario funcionarioBuscado = _iFuncionarioRepository.BuscarId(IDFuncionario);

                if (funcionarioBuscado == null)
                {
                    return NotFound();
                }
                _iFuncionarioRepository.Alterar(IDFuncionario, funcionario);
                return StatusCode(204);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);

            }
        }

        [Authorize(Roles = "2")]
        [HttpDelete("{IDFuncionario}")]
        public IActionResult Deletar(int IDFuncionario)
        {
            try
            {
                Funcionario funcionarioBuscado = _iFuncionarioRepository.BuscarId(IDFuncionario);

                if (funcionarioBuscado == null)
                {
                    return NotFound();
                }
                _iFuncionarioRepository.Deletar(IDFuncionario);
                return StatusCode(204);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
