﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Examination.Application.Commands.V1.Questions.DeleteQuestion
{
    public class DeleteQuestionCommand:IRequest<bool>
    {
        public string Id { get; set; }

        public DeleteQuestionCommand(string id)
        {
            Id = id;
        }
    }
}
