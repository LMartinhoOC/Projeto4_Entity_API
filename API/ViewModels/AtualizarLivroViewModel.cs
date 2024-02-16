using System.ComponentModel.DataAnnotations;

namespace API.ViewModels
{
    public class AtualizarLivroViewModel
    {
        [Required(ErrorMessage = "O Id do livro é obrigatório")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do livro é obrigatório")]
        [MaxLength(150, ErrorMessage = "O campo 'Nome' deve ter, no máximo, 150 caractéres de comprimento!")]
        public string Nome { get; set; }
        
        [MaxLength(100, ErrorMessage = $"O campo 'Autor' deve ter, no máximo, 100 caractéres de comprimento!")]
        public string Autor { get; set;}

        [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "O campo 'ISBN' deve ser composto apenas por números!")]
        public string Isbn { get; set;}
    }
}
