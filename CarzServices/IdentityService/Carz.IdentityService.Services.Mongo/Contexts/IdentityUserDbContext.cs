using Carz.IdentityService.Domain.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Carz.IdentityService.Services.Mongo.Contexts
{
    public class IdentityUserDbContext
    {
        private readonly MongoClient client;
        private readonly IMongoDatabase db;

        public IdentityUserDbContext(IConfiguration configuration)
        {
            client = new MongoClient(configuration.GetConnectionString("IdentityMongoDb"));
            db = client.GetDatabase(configuration.GetSection("IdentityMongoDbName").Value);
        }

        public IMongoCollection<IdentityUser> IdentityUsers => db.GetCollection<IdentityUser>("IdentityUsers");
    }
}
