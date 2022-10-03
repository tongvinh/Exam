using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examination.Shared.ExamResults
{
  public class ExamResultDto
  {
    public string Id { get; set; }
    public string ExamId { get; set; }
    public string ExamTitle { get; set; }
    public string UserId { get; set; }
    public string Email { get; set; }
    public string FullName { get; set; }
    public List<QuestionResultDto> QuestionResults { get; set; }
    public DateTime ExamStartDate { get; set; }
    public DateTime? ExamFinishDate { get; set; }
    public bool? Passed { get; set; }
    public bool Finished { get; set; }
  }
}