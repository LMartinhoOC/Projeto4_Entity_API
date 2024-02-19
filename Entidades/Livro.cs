using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace Entidades
{
    public class Livro
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Autor { get; set; }
        public string Isbn { get; set; }
        public bool Deletado { get; set; }

        public override string ToString()
        {
            this.Isbn = FazerISBN(this.Isbn);
            
            return $"Id: {this.Id}\n" +
                   $"Nome: {this.Nome}\n" +
                   $"Autor: {this.Autor}\n" +
                   $"ISBN: {this.Isbn}\n";
        }

        public string FazerISBN(string isbn)
        {
            if (isbn == null || isbn.Length != 13) return ("");
            
            string isbn1 = isbn.Substring(0, 3);
            string isbn2 = isbn.Substring(3, 1);
            string isbn3 = isbn.Substring(4, 2);
            string isbn4 = isbn.Substring(6, 6);
            string isbn5 = isbn.Substring(13, 1);

            string formato = $"{isbn1}-{isbn2}-{isbn3}-{isbn4}-{isbn5}";

            return (formato);
        }
    }
}
