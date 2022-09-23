using MediatR;

namespace Examination.Application.Commands.V1.Categories.UpdateCategory
{
    public class UpdateCategoryCommand:IRequest<bool>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string UrlPath { get; set; }
    }
}
