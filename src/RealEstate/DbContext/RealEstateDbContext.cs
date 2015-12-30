using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using RealEstate.Rentals;

namespace RealEstate.DbContext
{
    public class RealEstateDbContext: IRealEstateDbContext
    {
        private readonly string databaseName;
        private readonly MongoClient client;

        public RealEstateDbContext(IConfiguration config)
        {
            var config1 = config;
            var connetionString = config1.GetSection("Data").GetSection("mongoDb").Get<string>("ConnectionString");
            databaseName = config1.GetSection("Data").GetSection("Database").Get<string>("Name");
            client = new MongoClient(connetionString);
           
        }


        public IMongoDatabase Database => client.GetDatabase(databaseName);

        public IMongoCollection<RentalModel> RentalsCollection => Database.GetCollection<RentalModel>("rentalmodels");
    }

    public interface IRealEstateDbContext
    {
        IMongoDatabase Database { get; }

        IMongoCollection<RentalModel> RentalsCollection { get; }
    }
}
