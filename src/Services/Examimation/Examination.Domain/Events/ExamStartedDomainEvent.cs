using MediatR;

namespace Examination.Domain.Events
{
  public class ExamStartedDomainEvent : INotification
  {
    public string UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public ExamStartedDomainEvent(string userId, string firstName, string lastName)
    {
      UserId = userId;
      FirstName = firstName;
      LastName = lastName;
    }
  }
}