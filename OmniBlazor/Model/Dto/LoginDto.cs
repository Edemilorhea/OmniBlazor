using System.ComponentModel.DataAnnotations;

namespace OmniBlazor.Model.Dto;

public class LoginDto
{
    [Required(ErrorMessage = "請輸入帳號或信箱")]
    public string Identifier { get; set; } = null!;
    [Required(ErrorMessage = "請輸入密碼")]
    public string Password { get; set; } = null!;
    public string? JwtToken { get; set; } 
}
