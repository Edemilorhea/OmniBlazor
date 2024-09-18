using System.ComponentModel.DataAnnotations;

namespace OmniBlazor.Model;

public partial class Register
{
    public Guid RegisterId { get; set; }
    [Required]
    public required string Email { get; set; }
    [Required]
    public required string UserName { get; set; }
    [Required]
    public required string Password { get; set; }
}
