using Dados.Context;
using Dados.Interface;
using Entidades;
using Microsoft.EntityFrameworkCore;

namespace Dados.Persistencia
{
    public class LivroPersistence : ILivroPersistence
    {
        private readonly BaseDadosContext _contexto;

        public LivroPersistence(BaseDadosContext contexto)
        {
            this._contexto = contexto;
        }

        public void InserirLivro(Livro livro)
        {
            this._contexto.Livros.Add(livro);
            this._contexto.SaveChanges();
        }

        public void AtualizarLivro(Livro livro)
        {
            this._contexto.Entry(livro).State = EntityState.Modified;
            this._contexto.SaveChanges();
        }

        public void DeletarLivro(Livro livro) //não usado, pois exclui o registro do BD
        {
            this._contexto.Remove(livro);
            this._contexto.SaveChanges();
        }

        public Livro BuscarLivroPorId(int id)
        {
            return this._contexto
                .Livros
                .AsNoTracking()
                .Where(l => l.Id == id && !l.Deletado)
                .FirstOrDefault();
        }

        public List<Livro> ObterLivros()
        {
            return this._contexto
                .Livros
                .AsNoTracking()
                .Where(l => !l.Deletado)
                .ToList();
        }
    }
}
