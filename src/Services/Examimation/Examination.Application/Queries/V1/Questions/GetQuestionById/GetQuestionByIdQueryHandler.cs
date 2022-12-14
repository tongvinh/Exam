using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Examination.Domain.AggregateModels.QuestionAggregate;
using Examination.Shared.Questions;
using MediatR;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace Examination.Application.Queries.V1.Questions.GetQuestionById
{
    public class GetQuestionByIdQueryHandler : IRequestHandler<GetQuestionByIdQuery, QuestionDto>
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IClientSessionHandle _clientSessionHandle;
        private readonly IMapper _mapper;
        private readonly ILogger<GetQuestionByIdQueryHandler> _logger;

        public GetQuestionByIdQueryHandler(
            IQuestionRepository QuestionRepository,
            IMapper mapper,
            ILogger<GetQuestionByIdQueryHandler> logger,
            IClientSessionHandle clientSessionHandle
        )
        {
            _questionRepository = QuestionRepository ?? throw new ArgumentNullException(nameof(QuestionRepository));
            _clientSessionHandle = clientSessionHandle ?? throw new ArgumentNullException(nameof(_clientSessionHandle));
            _mapper = mapper;
            _logger = logger;

        }
        public async Task<QuestionDto> Handle(GetQuestionByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("BEGIN: GetQuestionByIdQueryHandler");

            var result = await _questionRepository.GetQuestionsByIdAsync(request.Id);
            var item = _mapper.Map<QuestionDto>(result);

            _logger.LogInformation("END: GetQuestionByIdQueryHandler");

            return item;
        }
    }
}
