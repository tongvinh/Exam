using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Examination.Shared.SeedWork;

namespace Examination.Shared.ExamResults
{
    public class ExamResultSearch:PagingParameters
    {
        public string Keyword { get; set; }
    }
}