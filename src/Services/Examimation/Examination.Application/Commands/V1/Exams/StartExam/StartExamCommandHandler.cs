using Examination.Domain.AggregateModels.ExamResultAggregate;
using MediatR;

namespace Examination.Application.Commands.V1.Exams.StartExam
{
  public class StartExamCommandHandler : IRequestHandler<StartExamCommand, bool>
  {
    private readonly IExamResultRepository _examResultRepository;
    public StartExamCommandHandler(IExamResultRepository examResultRepository)
    {
      _examResultRepository = examResultRepository;
    }
    public async Task<bool> Handle(StartExamCommand request, CancellationToken cancellationToken)
    {
      var examResult = await _examResultRepository.GetDetails(request.UserId, request.ExamId);

      try
      {
        if (examResult != null)
        {
          examResult.ExamStartDate = DateTime.Now;
          examResult.Finished = false;
          examResult.StartExam(request.FirstName, request.LastName);
        }
        else
        {
          examResult = ExamResult.CreateNewResult(request.UserId, request.ExamId);
          examResult.StartExam(request.FirstName, request.LastName);
          await _examResultRepository.InsertAsync(examResult);
        }
        return true;
      }
      catch (System.Exception)
      {
        throw;
      }
    }
  }
}