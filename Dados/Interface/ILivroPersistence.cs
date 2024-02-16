using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados.Interface
{
    public interface ILivroPersistence
    {
        List<Livro> ObterLivros();
        Livro BuscarLivroPorId(int id);
        void InserirLivro(Livro livro);
        void DeletarLivro(Livro livro);
        void AtualizarLivro(Livro livro);
    }
}
