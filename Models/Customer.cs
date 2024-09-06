using System.ComponentModel.DataAnnotations;

namespace web_asp.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите имя клиента")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Введите фамилию клиента")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Введите email клиента")]
        [EmailAddress(ErrorMessage = "Некорректный формат электронной почты")]
        public string Email { get; set; }
    }
}
