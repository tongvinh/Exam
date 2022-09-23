using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examination.Shared.Enums;

namespace Examination.Shared.Questions
{
    public class QuestionDto
    {
        public string Content { get; set; }
        public QuestionType QuestionType { get; set; }
        public Level Level { get; set; }
        public string CategoryId { get; set; }
        public IEnumerable<AnswerDto> Answers { get; set; }
        public string Explain { get; set; }
        public DateTime DateCreate { get; set; }
        public string OwnerUserId { get; set; }
    }
}
