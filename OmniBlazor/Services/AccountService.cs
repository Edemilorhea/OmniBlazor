using System.Net.Http.Json;
using System.Text.Json;
using Blazored.LocalStorage;
using OmniBlazor.Model;
using OmniBlazor.Model.Dto;

namespace OmniBlazor.Services;

public class AccountService : IAccountService
{
    public ServiceResponse<User> UserResponse { get; set; } = new ServiceResponse<User>();
    public ILocalStorageService _localStorageService;

    private readonly HttpClient _httpClientLoginApi;
    public AccountService(IHttpClientFactory httpClientFactory, ILocalStorageService localStorageService)
    {
        _httpClientLoginApi = httpClientFactory.CreateClient("LoginApi");
        _localStorageService = localStorageService;
    }

    public async Task<ServiceResponse<string>> LoginAsync(LoginDto login)
    {
        var response = await _httpClientLoginApi.PostAsJsonAsync("login", login);

        if(response.IsSuccessStatusCode){
            var content = await response.Content.ReadFromJsonAsync<LoginDto>();

            await _localStorageService.SetItemAsStringAsync("authToken", content.JwtToken);

            return new ServiceResponse<string>
            {
                Success = true,
                Message = "Login Successful",
                Data = content.JwtToken 
            };
        }
        else
        {
            return new ServiceResponse<string>
            {
                Success = false,
                Message = await response.Content.ReadAsStringAsync(),
                Data = null
            };
        }

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
