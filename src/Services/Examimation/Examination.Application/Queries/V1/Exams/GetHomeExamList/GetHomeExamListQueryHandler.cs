using AutoMapper;
using Examination.Application.Queries.GetHomeExamList;
using Examination.Domain.AggregateModels.ExamAggregate;
using Examination.Dtos.Exams;
using MediatR;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace Examination.Application.Queries.V1.Exams.GetHomeExamList
{
    public class GetHomeExamListQueryHandler : IRequestHandler<GetHomeExamListQuery, IEnumerable<ExamDto>>
    {
        private readonly IExamRepository _examRepository;
        private readonly IMapper _mapper;
        private readonly IClientSessionHandle _clientSessionHandle;
        private readonly ILogger<GetHomeExamListQueryHandler> _logger;
        public GetHomeExamListQueryHandler(IExamRepository examRepository, IMapper mapper, IClientSessionHandle clientSessionHandle, ILogger<GetHomeExamListQueryHandler> logger)
        {
            _clientSessionHandle = clientSessionHandle ?? throw new ArgumentNullException(nameof(_clientSessionHandle));
            _mapper = mapper;
            _examRepository = examRepository ?? throw new ArgumentNullException(nameof(examRepository));
            _logger = logger;
        }
        public async Task<IEnumerable<ExamDto>> Handle(GetHomeExamListQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("BEGIN: GetHomeExamListQueryHandler");

            var exams = await _examRepository.GetExamListAsync();
            var examDtos = _mapper.Map<IEnumerable<ExamDto>>(exams);

            _logger.LogInformation("END: GetHomeExamListQueryHandler");
            return examDtos;
        }
    }
}