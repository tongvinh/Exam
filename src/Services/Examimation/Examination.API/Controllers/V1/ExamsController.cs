using Examination.Application.Queries.V1.Exams.GetHomeExamList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Examination.API.Controllers.V1
{
  
  public class ExamsController : BaseController
  {
    private readonly IMediator _mediator;
    private readonly ILogger<ExamsController> _logger;
    public ExamsController(IMediator mediator, ILogger<ExamsController> logger)
    {
      _logger = logger;
      _mediator = mediator;
    }
    [HttpGet]
    public async Task<IActionResult> GetExamList()
    {
      _logger.LogInformation("BEGIN: GetExamList");
      var query = new GetHomeExamListQuery();
      var queryResult = await _mediator.Send(query);
       _logger.LogInformation("END: GetExamList");
      return Ok(queryResult);
    }
  }
}