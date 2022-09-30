using Examination.Domain.AggregateModels.ExamResultAggregate;
using Examination.Infrastructure.MongoDb.SeedWork;
using MediatR;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Examination.Infrastructure.MongoDb.Repositories
{
    public class ExamResultRepository : BaseRepository<ExamResult>, IExamResultRepository
    {
        public ExamResultRepository(IMongoClient mongoClient, IOptions<ExamSettings> settings) :
          base(mongoClient, settings, Constants.Collections.ExamResult)
        {
        }

        public async Task<ExamResult> GetDetails(string id)
        {
            var filter = Builders<ExamResult>.Filter.Where(s => s.Id == id);
            return await Collection.Find(filter).FirstOrDefaultAsync();
        }
    }
}