using Examination.Shared.ExamResults;
using Examination.Shared.SeedWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PortalApp.Services.Interface;

namespace PortalApp.Pages.Profile
{
  public class ExamHistoriesModel : PageModel
  {

    [BindProperty]
    public PagedList<ExamResultDto> ExamResults { set; get; }
    private readonly IExamResultService _examResultService;
    public ExamHistoriesModel(IExamResultService examResultService)
    {
      _examResultService = examResultService;
    }

    public async Task OnGetAsync([FromQuery] PagingParameters request)
    {
      var result = await _examResultService.GetExamResultsByUserIdPagingAsync(request);
      if (result.IsSuccessed)
      {
        ExamResults = result.ResultObj;
      }
    }
  }
}