using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examination.Shared.Enums;

namespace Examination.Shared.Questions
{
    public class UpdateQuestionRequest
    {
        [Required] public string Id { get; set; }
        [Required] public string Content { get; set; }
        [Required] public QuestionType QuestionType { get; set; }
        [Required] public Level Level { get; set; }
        [Required] public string CategoryId { get; set; }
        [Required] public List<AnswerDto> Answers { get; set; } = new List<AnswerDto>();
        public string Explain { get; set; }
    }
}
