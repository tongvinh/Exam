using Examination.Domain.AggregateModels.CategoryAggregate;
using Examination.Shared.SeedWork;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Examination.Application.Commands.V1.Exams.DeleteExam
{
    public class DeleteExamCommandHandler : IRequestHandler<DeleteExamCommand, ApiResult<bool>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<DeleteExamCommandHandler> _logger;

        public DeleteExamCommandHandler(
                ICategoryRepository categoryRepository,
                ILogger<DeleteExamCommandHandler> logger
            )
        {
            _categoryRepository = categoryRepository;
            _logger = logger;

        }
        public async Task<ApiResult<bool>> Handle(DeleteExamCommand request, CancellationToken cancellationToken)
        {
            var itemToUpdate = await _categoryRepository.GetCategoriesByIdAsync(request.Id);
            if (itemToUpdate == null)
            {
                _logger.LogError($"Item is not found {request.Id}");
                return new ApiErrorResult<bool>(400, $"Item is not found {request.Id}");
            }
        
                await _categoryRepository.DeleteAsync(request.Id);
                return new ApiSuccessResult<bool>(200, true, "Delete successful");
        }
    }
}
