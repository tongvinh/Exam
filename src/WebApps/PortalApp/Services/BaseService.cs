using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Examination.Shared.SeedWork;
using Microsoft.AspNetCore.Authentication;

namespace PortalApp.Services
{
  public class BaseService
  {
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public BaseService(IHttpClientFactory httpClientFactory,
        IHttpContextAccessor httpContextAccessor)
    {
      _httpClientFactory = httpClientFactory;
      _httpContextAccessor = httpContextAccessor;
    }

    public async Task<ApiResult<T>> GetAsync<T>(string url, bool isSecuredService = false)
    {
      using (var client = _httpClientFactory.CreateClient("BackendApi"))
      {
        if (isSecuredService)
        {
          var token = await _httpContextAccessor.HttpContext.GetTokenAsync("access_token");
          client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
        return await client.GetFromJsonAsync<ApiResult<T>>(url, new JsonSerializerOptions()
        {
          PropertyNameCaseInsensitive = true
        });
      }
    }
    public async Task<ApiResult<TResponse>> PostAsync<TRequest, TResponse>(string url, TRequest requestContent, bool isSecuredService = true)
    {
      var client = _httpClientFactory.CreateClient("BackendApi");
      StringContent httpContent = null;
      if (requestContent != null)
      {
        var json = JsonSerializer.Serialize(requestContent);
        httpContent = new StringContent(json, Encoding.UTF8, "application/json");
      }
      if (isSecuredService)
      {
        var token = await _httpContextAccessor.HttpContext.GetTokenAsync("access_token");
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
      }
      var response = await client.PostAsync(url, httpContent);
      var body = await response.Content.ReadAsStringAsync();

      if (response.IsSuccessStatusCode)
      {
                var result = JsonSerializer.Deserialize<ApiResult<TResponse>>(body, new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                }); ;
                return result;
      }
      throw new Exception(body);
    }
    public async Task<ApiResult<bool>> PutAsync<TRequest, TResponse>(string url, TRequest requestContent, bool isSecuredService = true)
    {
      var client = _httpClientFactory.CreateClient("BackendApi");
      HttpContent httpContent = null;
      if (requestContent != null)
      {
        var json = JsonSerializer.Serialize(requestContent);
        httpContent = new StringContent(json, Encoding.UTF8, "application/json");
      }
      if (isSecuredService)
      {
        var token = await _httpContextAccessor.HttpContext.GetTokenAsync("access_token");
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
      }
      var response = await client.PutAsync(url, httpContent);
      var body = await response.Content.ReadAsStringAsync();

      return JsonSerializer.Deserialize<ApiResult<bool>>(body, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
    }
  }
}