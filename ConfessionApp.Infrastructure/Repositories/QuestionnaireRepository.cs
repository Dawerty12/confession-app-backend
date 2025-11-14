using ConfessionApp.Application.Interfaces;
using ConfessionApp.Core.Entities;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace ConfessionApp.Infrastructure.Repositories
{
    public class QuestionnaireRepository : IQuestionnaireRepository
    {
        private readonly IMongoCollection<Questionnaire> _collection;

        public QuestionnaireRepository(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("MongoDb");
            var databaseName = configuration["DatabaseName"] ?? "confession_db";
            
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            
            _collection = database.GetCollection<Questionnaire>("commandments");
        }


        public async Task<Questionnaire?> GetStepByIdAsync(int id)
        {
            return await _collection.Find(q => q.Id == id)
                                    .FirstOrDefaultAsync();
        }

        public async Task<List<int>> GetStepsOrderAsync()
        {
            var sort = Builders<Questionnaire>.Sort.Ascending(q => q.Id);
            var projection = Builders<Questionnaire>.Projection.Include(q => q.Id).Exclude("_id");

            var steps = await _collection.Find(_ => true) 
                                         .Sort(sort)
                                         .Project(projection)
                                         .ToListAsync();

            return steps.Select(doc => doc["id"].AsInt32).ToList();
        }
    }
}