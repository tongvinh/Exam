using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using AdminApp.Services.Interfaces;
using Examination.Shared.ExamResults;
using Examination.Shared.SeedWork;
using Microsoft.AspNetCore.WebUtilities;

namespace AdminApp.Services
{
  public class ExamResultService : IExamResultService
  {
    public HttpClient _httpClient;

    public ExamResultService(HttpClient httpClient)
    {
      _httpClient = httpClient;
    }
    public async Task<ApiResult<ExamResultDto>> GetExamResultByIdAsync(string id)
    {
      var result = await _httpClient.GetFromJsonAsync<ApiResult<ExamResultDto>>($"/api/v1/ExamResults/{id}");
      return result;
    }

    public async Task<ApiResult<PagedList<ExamResultDto>>> GetExamResultsPagingAsync(ExamResultSearch searchInput)
    {
      var queryStringParam = new Dictionary<string, string>
      {
        ["pageIndex"] = searchInput.PageNumber.ToString(),
        ["pageSize"] = searchInput.PageSize.ToString()
      };
      if (!string.IsNullOrEmpty(searchInput.Keyword))
        queryStringParam.Add("keyword", searchInput.Keyword);

      string url = QueryHelpers.AddQueryString("/api/v1/ExamResults/paging", queryStringParam);

      var result = await _httpClient.GetFromJsonAsync<ApiResult<PagedList<ExamResultDto>>>(url);
      return result;
    }
  }
}