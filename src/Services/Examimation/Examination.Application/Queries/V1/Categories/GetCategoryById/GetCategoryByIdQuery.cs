using Examination.Shared.Categories;
using MediatR;

namespace Examination.Application.Queries.V1.Categories.GetCategoryById
{
    public class GetCategoryByIdQuery:IRequest<CategoryDto>
    {
        public string Id { get; set; }

        public GetCategoryByIdQuery(string id)
        {
            Id = id;
        }
    }
}
