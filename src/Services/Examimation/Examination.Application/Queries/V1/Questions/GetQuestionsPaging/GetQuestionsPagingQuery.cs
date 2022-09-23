using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examination.Shared.Questions;
using Examination.Shared.SeedWork;
using MediatR;

namespace Examination.Application.Queries.V1.Questions.GetQuestionsPaging
{
    public class GetQuestionsPagingQuery: IRequest<PagedList<QuestionDto>>
    {
        public string SearchKeyword { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
