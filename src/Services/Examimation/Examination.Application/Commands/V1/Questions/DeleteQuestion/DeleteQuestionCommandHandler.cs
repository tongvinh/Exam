﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examination.Domain.AggregateModels.QuestionAggregate;
using Examination.Shared.SeedWork;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Examination.Application.Commands.V1.Questions.DeleteQuestion
{
    public class DeleteQuestionCommandHandler : IRequestHandler<DeleteQuestionCommand, ApiResult<bool>>
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly ILogger<DeleteQuestionCommandHandler> _logger;

        public DeleteQuestionCommandHandler(
            IQuestionRepository QuestionRepository,
            ILogger<DeleteQuestionCommandHandler> logger
        )
        {
            _questionRepository = QuestionRepository;
            _logger = logger;

        }
        public async Task<ApiResult<bool>> Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
        {
            var itemToUpdate = await _questionRepository.GetQuestionsByIdAsync(request.Id);
            if (itemToUpdate == null)
            {
                _logger.LogError($"Item is not found {request.Id}");
                return new ApiErrorResult<bool>($"Item is not found {request.Id}");
            }


            await _questionRepository.DeleteAsync(request.Id);
            return new ApiSuccessResult<bool>(true, "Delete successful");

        }
    }
}
