using OmniBlazor.Model;
using OmniBlazor.Model.Dto;

namespace OmniBlazor.Services;

public interface IAccountService
{
    public Task<ServiceResponse<bool>> Register(Register register);
    public Task<ServiceResponse<bool>> Login(LoginDto login);
}
