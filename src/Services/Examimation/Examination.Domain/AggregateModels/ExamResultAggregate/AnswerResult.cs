using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Examination.Domain.SeedWork;
using MongoDB.Bson.Serialization.Attributes;

namespace Examination.Domain.AggregateModels.ExamResultAggregate
{
  public class AnswerResult : Entity
  {
    public AnswerResult()
    {
    }
    public AnswerResult(string id, string content, bool? userChosen)
    {
      Id = id;
      UserChosen = userChosen;
      Content = content;
    }

    [BsonElement("content")]
    public string Content { get; set; }

    [BsonElement("userChosen")]
    public bool? UserChosen { get; set; }
  }
}