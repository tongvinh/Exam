using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Examination.Shared.ExamResults;
using Examination.Shared.SeedWork;

namespace AdminApp.Services.Interfaces
{
  public interface IExamResultService
  {
    Task<ApiResult<PagedList<ExamResultDto>>> GetExamResultsPagingAsync(ExamResultSearch search);
    Task<ApiResult<ExamResultDto>> GetExamResultByIdAsync(string id);
  }
}