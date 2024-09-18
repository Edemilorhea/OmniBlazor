using System.ComponentModel.DataAnnotations;

namespace OmniBlazor.Model;

public partial class Register
{
    public Guid RegisterId { get; set; }
    [Required(ErrorMessage = "Email不得為空")]
    [EmailAddress(ErrorMessage = "Email格式不正確")]
    public string? Email { get; set; }
    [Required(ErrorMessage = "UserName不得為空")]
    [MinLength(3, ErrorMessage = "UserName長度不得小於3")]
    [MaxLength(20, ErrorMessage = "UserName長度不得大於20")]
    public string? UserName { get; set; }
    [Required(ErrorMessage = "Password不得為空")]
    [MinLength(6, ErrorMessage = "Password長度不得小於6")]
    public string? Password { get; set; }
}
