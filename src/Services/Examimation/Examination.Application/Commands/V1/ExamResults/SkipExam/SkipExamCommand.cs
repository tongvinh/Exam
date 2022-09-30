using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Examination.Shared.SeedWork;
using MediatR;

namespace Examination.Application.Commands.V1.ExamResults.SkipExam
{
    public class SkipExamCommand:IRequest<ApiResult<bool>>
    {
        public string ExamResultId { get; set; }
    }
}