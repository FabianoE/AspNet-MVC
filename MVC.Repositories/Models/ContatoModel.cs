using System.ComponentModel.DataAnnotations;

namespace MVC.Repositories.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome não pode ser nulo")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O email não pode ser nulo")]
        [EmailAddress(ErrorMessage = "O email é inválido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O celular não pode ser nulo")]
        [Phone(ErrorMessage = "O celular é inválido")]
        public string Celular { get; set; }
    }
}
