using OmniBlazor.Model;
using OmniBlazor.Model.Dto;

namespace OmniBlazor.Services;

public interface IAccountService
{
    ServiceResponse<User> UserResponse { get; set; }
    public Task<ServiceResponse<RegisterResponseDto>> RegisterAsync(Register register);
    public Task<ServiceResponse<string>> LoginAsync(LoginDto login);
}
