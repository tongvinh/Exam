using AutoMapper;
using Examination.Domain.AggregateModels.CategoryAggregate;
using Examination.Shared.Categories;
using Examination.Shared.SeedWork;
using MediatR;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace Examination.Application.Queries.V1.Categories.GetCategoriesPaging
{
    internal class GetCategoriesPagingQueryHandler : IRequestHandler<GetCategoriesPagingQuery, PagedList<CategoryDto>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetCategoriesPagingQueryHandler> _logger;
        private readonly IClientSessionHandle _clientSessionHandle;

        public GetCategoriesPagingQueryHandler(
            ICategoryRepository categoryRepository,
            IMapper mapper,
            ILogger<GetCategoriesPagingQueryHandler> logger,
            IClientSessionHandle clientSessionHandle)
        {
            _categoryRepository = categoryRepository?? throw new ArgumentNullException(nameof(categoryRepository));
            _mapper = mapper;
            _logger = logger;
            _clientSessionHandle = clientSessionHandle ?? throw new ArgumentNullException(nameof(clientSessionHandle));
        }
        public async Task<PagedList<CategoryDto>> Handle(GetCategoriesPagingQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("BEGIN: GetHomeExamListQueryHandler");

            var result =
                await _categoryRepository.GetCategoriesPagingAsync(request.SearchKeyWord, request.PageIndex,
                    request.PageSize);
            var items = _mapper.Map<List<CategoryDto>>(result.Item1);

            _logger.LogInformation("END: GetHomeExamListQueryHandler");
            return new PagedList<CategoryDto>(items, result.Item2, request.PageIndex, request.PageSize);
        }
    }
}
