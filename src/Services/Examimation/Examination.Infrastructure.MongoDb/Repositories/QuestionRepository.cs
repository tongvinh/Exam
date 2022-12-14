using Examination.Domain.AggregateModels.QuestionAggregate;
using Examination.Infrastructure.MongoDb.SeedWork;
using MediatR;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Examination.Infrastructure.MongoDb.Repositories
{
    public class QuestionRepository : BaseRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(IMongoClient mongoClient, IOptions<ExamSettings> settings) :
          base(mongoClient, settings, Constants.Collections.Question)
        {
        }

        public async Task<Question> GetQuestionsByIdAsync(string id)
        {
            FilterDefinition<Question> filter = Builders<Question>.Filter.Eq(s => s.Id, id);
            return await Collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<Tuple<List<Question>, long>> GetQuestionsPagingAsync(string searchKeyword, int pageIndex, int pageSize)
        {
            FilterDefinition<Question> filter = Builders<Question>.Filter.Empty;
            if (!string.IsNullOrEmpty(searchKeyword))
                filter = Builders<Question>.Filter.Eq(s => s.Content, searchKeyword);

            var totalRow = await Collection.Find(filter).CountDocumentsAsync();
            var items = await Collection.Find(filter)
                .Skip((pageIndex - 1) * pageSize)
                .Limit(pageSize)
                .ToListAsync();

            return new Tuple<List<Question>, long>(items, totalRow);
        }
    }
}