using System.ComponentModel.DataAnnotations;

namespace API.ViewModels
{
    public class DeletarLivroViewModel
    {
        [Required(ErrorMessage = "O Id do livro é obrigatório")]
        public int Id { get; set; }
        public bool Deletado { get; set; }
    }
}
