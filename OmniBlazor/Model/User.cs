using System.ComponentModel.DataAnnotations;

namespace OmniBlazor.Model;

public class User
{
    [Required]
    public required Guid userId { get; set; }
    public required string UserName { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
}
