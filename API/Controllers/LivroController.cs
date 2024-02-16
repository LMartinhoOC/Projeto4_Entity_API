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
        [Route("")]
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
        [Route("")]
        public ActionResult BuscarLivroPorId(int id)
        {
            try
            {
                Livro livro = this._livroPersistence.BuscarLivroPorId(id);

                if(livro == null)
                {
                    return NotFound($"O livro com o Id {id} não foi encontrado.");
                }

                return Ok(livro);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("")]
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
                    Livro livro =       new Livro();
                    livro.Nome =        model.Nome;
                    livro.Autor =       model.Autor;
                    livro.Isbn =        model.ISBN;
                    livro.Deletado =    false;

                    this._livroPersistence.InserirLivro(livro);

                    return Ok($"Livro cadastrado com sucesso:\n{livro} ");
                }
            }catch (Exception ex)
            {
                return StatusCode(500, ex?.Message);
            }
        }

        [HttpPut]
        [Route("")]
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
                        livro.Nome              = model.Nome;
                        livro.Autor             = model.Autor;
                        livro.Isbn              = model.Isbn;
                        livro.Deletado          = false;

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
                    Livro livro = new Livro();
                    livro.Deletado = true;

                    this._livroPersistence.AtualizarLivro(livro);
                    return Ok($"Livro {livro.Nome} foi deletado.");
                }
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex?.Message);
            }
        }
    }
}
