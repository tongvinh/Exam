using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examination.Shared.Questions;
using MediatR;

namespace Examination.Application.Queries.V1.Questions.GetQuestionById
{
    public class GetQuestionByIdQuery:IRequest<QuestionDto>
    {
        public string Id { get; set; }

        public GetQuestionByIdQuery(string id)
        {
            Id = id;
        }
    }
}
