using Exoapi.Models;
using Exoapi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exoapi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]

    [Authorize(Roles = "2, 1")]

    public class ProjetoController : ControllerBase
    {
        private readonly ProjetoRepository _projetoRepository;

        public ProjetoController(ProjetoRepository projetoRepository)
        {
            _projetoRepository = projetoRepository;
        }


        [Authorize(Roles = "1")]
        [HttpGet]
        
        public IActionResult Listar() 
        {
            try
            {
                return Ok(_projetoRepository.Listar());
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        [Authorize(Roles = "2")]
        [HttpGet("{IDProjeto}")]
        public IActionResult BuscarId(int IDProjeto)
        {
            try
            {
                Projeto projetoBuscado = _projetoRepository.BuscarId(IDProjeto);

                if (projetoBuscado == null)
                {
                    return NotFound();
                }
                return Ok(projetoBuscado);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        [Authorize(Roles = "2")]
        [HttpPost]

        public IActionResult Cadastrar(Projeto projeto)
        {
            try
            {
                _projetoRepository.Cadastrar(projeto);
                return StatusCode(201);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        [Authorize(Roles = "2")]
        [HttpPut("{IDProjeto}")]

        public IActionResult Atualizar(int IDProjeto, Projeto projeto)
        {
            try
            {
                Projeto projetoBuscado = _projetoRepository.BuscarId(IDProjeto);

                if (projetoBuscado == null)
                {
                    return NotFound();
                }
                _projetoRepository.Atualizar(IDProjeto, projeto);
                return StatusCode(204);
            }
            catch(Exception e)
            {

                throw new Exception(e.Message);

            }
        }

        [Authorize(Roles = "2")]
        [HttpDelete("{IDProjeto}")]
        public IActionResult Deletar(int IDProjeto)
        {
            try
            {
                Projeto projetoBuscado = _projetoRepository.BuscarId(IDProjeto);

                if (projetoBuscado == null)
                {
                    return NotFound();
                }
                _projetoRepository.Deletar(IDProjeto);
                return StatusCode(204);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

    }
}
