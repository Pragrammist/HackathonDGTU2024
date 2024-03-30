
using System.ComponentModel.DataAnnotations;

namespace HackathonDGTU.Models.User;

public class UserRegister
{
    [EmailAddress(ErrorMessage = "Введите почту правильно")]
    public string Email { get; set; } = null!;

    [RegularExpression("^[a-zA-Z0-9]+$", ErrorMessage = "Введите логин правильно")]
    public string Login { get; set; } = null!;

    [Compare(nameof(Password), ErrorMessage = "Введите пароль правильно")]
    public string RepeatPassword { get; set; } = null!;

    [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$", ErrorMessage = "Введите повтор пароля правильно")]
    public string Password { get; set; } = null!;
}