using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace API.ViewModels
{
    public class InserirLivroViewModel
    {
        [Required (ErrorMessage = "O campo 'Nome' é obrigatório!")]
        [MaxLength(150, ErrorMessage = "O campo 'Nome' deve ter, no máximo, 150 caractéres de comprimento!")]
        public string Nome { get; set; }
        [Required (ErrorMessage = "O campo 'Autor' é obrigatório!")]
        [MaxLength(100, ErrorMessage = $"O campo 'Autor' deve ter, no máximo, 100 caractéres de comprimento!") ]
        public string Autor { get; set; }

        [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "O campo 'ISBN' deve ser composto apenas por números!")]
        public string? ISBN { get; set; }

    }
}
