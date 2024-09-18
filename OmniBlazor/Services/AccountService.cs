using System.Net.Http.Json;
using System.Text.Json;
using OmniBlazor.Model;
using OmniBlazor.Model.Dto;

namespace OmniBlazor.Services;

public class AccountService : IAccountService
{
    public ServiceResponse<User> UserResponse { get; set; } = new ServiceResponse<User>();
    private readonly HttpClient _httpClientLoginApi;
    public AccountService(IHttpClientFactory httpClientFactory)
    {
        _httpClientLoginApi = httpClientFactory.CreateClient("LoginApi");
    }

    public Task<ServiceResponse<User>> LoginAsync(LoginDto login)
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceResponse<RegisterResponseDto>> RegisterAsync(Register register)
    {
        var response = await _httpClientLoginApi.PostAsJsonAsync<Register>("register", register);
        if(response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadFromJsonAsync<RegisterResponseDto>();

            return new ServiceResponse<RegisterResponseDto>
            {
                Success = true,
                Message = "Registration Successful",
                Data = content
            };
        }
        else
        {
            return new ServiceResponse<RegisterResponseDto>
            {
                Success = false,
                Message = await response.Content.ReadAsStringAsync(),
                Data = null
            };
        }
    }
}
