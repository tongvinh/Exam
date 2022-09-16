using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examination.Dtos
{
    public class ExamDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDesc { get; set; }
        public int NumberOfQuestions { get; set; }
        public TimeSpan? Duration { get; set; }
        public Enums.Level Level { get; set; }
        public DateTime DateCreated { get; set; }

    }
}