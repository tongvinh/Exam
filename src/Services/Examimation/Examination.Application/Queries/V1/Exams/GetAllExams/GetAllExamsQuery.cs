using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Examination.Shared.Exams;
using Examination.Shared.SeedWork;
using MediatR;

namespace Examination.Application.Queries.V1.Exams.GetAllExams
{
    public class GetAllExamsQuery:IRequest<ApiResult<IEnumerable<ExamDto>>>
    {
        public GetAllExamsQuery()
        {
        }
    }
}