﻿using Carz.AdvertisementService.Domain.Entities;
using Carz.Common.Configuration;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carz.AdvertisementService.Services.Mongo.Contexts
{
    public class AdvertisementDbContext
    {
        private IMongoDatabase db;
        private IMongoClient client;
        public AdvertisementDbContext(IConfiguration configuration)
        {
            var mongoConfig = new MongoDbConfiguration();
            configuration.Bind(nameof(mongoConfig), configuration);
            client = new MongoClient(mongoConfig.ConnectionString);
            db = client.GetDatabase(mongoConfig.DatabaseName);
        }
        // Required for creating sessions for transactions
        public IMongoClient Client => client;

        // Collections 
        public IMongoCollection<Advertisement> Advertisements => db.GetCollection<Advertisement>("Advertisements");
        public IMongoCollection<Bid> Bids => db.GetCollection<Bid>("Bids");
        public IMongoCollection<HealthStatus> HealthStatuses => db.GetCollection<HealthStatus>("HealthStatuses");
        public IMongoCollection<Ownership> Ownerships => db.GetCollection<Ownership>("Ownerships");
    }
}
