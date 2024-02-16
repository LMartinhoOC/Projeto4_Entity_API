namespace API.ViewModels
{
    public class LivroViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Autor { get; set; }
        public string Isbn { get; set; }
        public bool Deletado { get; set; }
    }
}
