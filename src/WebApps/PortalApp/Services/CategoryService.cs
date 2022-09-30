using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Examination.Shared.Categories;
using Examination.Shared.SeedWork;
using PortalApp.Services.Interface;

namespace PortalApp.Services
{
  public class CategoryService :BaseService, ICategoryService
  {
    public CategoryService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor) : base(httpClientFactory, httpContextAccessor)
    {
    }

    public async Task<ApiResult<List<CategoryDto>>> GetAllCategoriesAsync()
    {
      var result = await GetAsync<List<CategoryDto>>("/api/v1/categories");
      return result;
    }
  }
}