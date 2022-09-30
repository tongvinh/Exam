using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Examination.Shared.ExamResults;
using Examination.Shared.SeedWork;
using MediatR;

namespace Examination.Application.Commands.V1.ExamResults.StartExam
{
    public class StartExamCommand:IRequest<ApiResult<ExamResultDto>>
    {
        public string ExamId { get; set; }
    }
}