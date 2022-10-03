using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Examination.Domain.AggregateModels.ExamResultAggregate;
using Examination.Shared.ExamResults;
using Examination.Shared.SeedWork;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Examination.Application.Queries.V1.ExamResults.GetExamResultsPaging
{
  public class GetExamResultsPagingQueryHandler : IRequestHandler<GetExamResultsPagingQuery, ApiResult<PagedList<ExamResultDto>>>
  {

    private readonly IExamResultRepository _examResultRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<GetExamResultsPagingQuery> _logger;

    public GetExamResultsPagingQueryHandler(
            IExamResultRepository examResultRepository,
            IMapper mapper,
            ILogger<GetExamResultsPagingQuery> logger)
    {
      _examResultRepository = examResultRepository ?? throw new ArgumentNullException(nameof(examResultRepository));
      _mapper = mapper;
      _logger = logger;

    }
    public async Task<ApiResult<PagedList<ExamResultDto>>> Handle(GetExamResultsPagingQuery request, CancellationToken cancellationToken)
    {
      _logger.LogInformation("BEGIN: GetHomeExamListQueryHandler");

      var result = await _examResultRepository.GetExamResultsPagingAsync(
        request.Keyword,
        request.PageIndex,
        request.PageSize
      );

      var items = _mapper.Map<List<ExamResultDto>>(result.Items);

      _logger.LogInformation("END: GetHomeExamListQueryHandler");
      var pagedItems = new PagedList<ExamResultDto>(items, result.MetaData.TotalCount, request.PageIndex, request.PageSize);

      return new ApiSuccessResult<PagedList<ExamResultDto>>(200, pagedItems);
    }
  }
}