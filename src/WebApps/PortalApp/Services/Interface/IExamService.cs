using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Examination.Shared.Categories;
using Examination.Shared.Exams;
using Examination.Shared.SeedWork;

namespace PortalApp.Services.Interface
{
  public interface IExamService
  {
    Task<ApiResult<PagedList<ExamDto>>> GetExamsPagingAsync(ExamSearch search);
    Task<ApiResult<ExamDto>> GetExamByIdAsync(string id);
  }
}