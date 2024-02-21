using API.ViewModels;
using Dados.Interface;
using Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly ILivroPersistence _livroPersistence;

        public LivroController(ILivroPersistence livroPersistence)
        {
            this._livroPersistence = livroPersistence;
        }

        [HttpGet]
        [Route("/VerLista")]
        public ActionResult BuscarLivro()
        {
            try
            {
                List<Livro> livros = this._livroPersistence.ObterLivros();

                return Ok(livros);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("/BuscarPorId")]
        public ActionResult BuscarLivroPorId(int id)
        {
            try
            {
                Livro livro = this._livroPersistence.BuscarLivroPorId(id);

                if(livro == null)
                {
                    return NotFound($"O livro com o ID {id} não foi encontrado.");
                }

                return Ok(livro);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("/InserirLivro")]
        public ActionResult InserirLivro(InserirLivroViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                else
                {
                    if (!String.IsNullOrEmpty(model.ISBN) && model.ISBN.Length < 13)
                    {
                        ModelState.AddModelError("ISBN", "O código ISBN deve ter 13 dígitos ou ser nulo");

                        return BadRequest(ModelState);

                        //return BadRequest("O código ISBN deve ter 13 dígitos ou ser nulo");
                    }
                    else
                    {
                        Livro livro = new Livro();
                        livro.Nome = model.Nome;
                        livro.Autor = model.Autor;
                        livro.Isbn = model.ISBN;
                        livro.Deletado = false;

                        this._livroPersistence.InserirLivro(livro);

                        return Ok($"Livro cadastrado com sucesso:\n{livro} ");
                    }                   
                }
            }catch (Exception ex)
            {
                return StatusCode(500, ex?.Message);
            }
        }

        [HttpPut]
        [Route("/EditarLivro")]
        public ActionResult EditarLivro(AtualizarLivroViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                else
                {
                    Livro liv = this._livroPersistence.BuscarLivroPorId(model.Id);
                    
                    if(liv == null)
                    {
                        return NotFound($"O livro com o Id {model.Id} não foi encontrado.");
                    }
                    else
                    {
                        Livro livro             = new Livro();
                        livro.Id                = model.Id;
                        livro.Nome              = model.Nome;
                        livro.Autor             = model.Autor;
                        livro.Isbn              = model.Isbn;

                        this._livroPersistence.AtualizarLivro(livro);

                        return Ok(livro);
                    }
                }
            }catch (Exception ex)
            {
                return StatusCode(500, ex?.Message);
            }
        }

        [HttpDelete]
        [Route("/RemoverLivro")]
        public ActionResult DeletarLivro(int id)
        {
            try
            {
                Livro liv = this._livroPersistence.BuscarLivroPorId(id);

                if(liv == null)
                {
                    return NotFound($"O livro com o Id {id} não foi encontrado.");
                }
                else
                {
                    liv.Deletado = true;

                    this._livroPersistence.AtualizarLivro(liv);
                    return Ok($"Livro {liv.Nome} foi deletado.");
                }
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex?.Message);
            }
        }
    }
}
