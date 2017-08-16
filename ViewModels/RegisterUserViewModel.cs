using System.ComponentModel.DataAnnotations;

namespace WifeyApp.ViewModels
{
    public class RegisterUserViewModel
    {
        [Required, MaxLength(256), DataType(DataType.EmailAddress)]
        public string Username { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

    }
}
