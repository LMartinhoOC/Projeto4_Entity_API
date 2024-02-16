using System.ComponentModel.DataAnnotations;

namespace Projeto4.API.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O login é obrigatório")]
        public string login { get; set; }
        [Required(ErrorMessage = "A senha é obrigatória")]
        public string password { get; set; }
    }
}
