using Examination.Shared.Categories;
using Examination.Shared.SeedWork;

namespace PortalApp.Services.Interface
{
  public interface ICategoryService
    {
        Task<ApiResult<List<CategoryDto>>> GetAllCategoriesAsync();
    }
}