﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examination.Shared.Enums;
using Examination.Shared.Questions;
using Examination.Shared.SeedWork;
using MediatR;

namespace Examination.Application.Commands.V1.Questions.CreateQuestion
{
    public class CreateQuestionCommand:IRequest<ApiResult<QuestionDto>>
    {
        [Required]
        public string Content { get; set; }

        [Required]
        public QuestionType QuestionType { get; set; }

        [Required]
        public Level Level { set; get; }

        [Required]
        public string CategoryId { get; set; }

        [Required]
        public List<AnswerDto> Answers { set; get; } = new List<AnswerDto>();

        public string Explain { get; set; }
    }
}
