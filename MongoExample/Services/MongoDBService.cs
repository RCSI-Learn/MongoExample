using MongoExample.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
namespace MongoExample.Services {
    public class MongoDBService {
        private readonly IMongoCollection<Sales> _salesCollection;
        public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings) {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DataBaseName);
            _salesCollection = database.GetCollection<Sales>(mongoDBSettings.Value.CollectionName);
        }
        public async Task CreateAsync(MongoExample.Models.Sales sales) {
            await _salesCollection.InsertOneAsync(sales);
            return;
        }
        
        public async Task<List<Sales>> GetAsync() {
            return await _salesCollection.Find(new BsonDocument()).ToListAsync();
        }
        //doesnt work, add a list
        public async Task AddToSalesListAsync(int id, int SaleId) {
            FilterDefinition<Sales> filter = Builders<Sales>.Filter.Eq("_id", id);
            UpdateDefinition<Sales> update = Builders<Sales>.Update.AddToSet<int>("_id", SaleId);
            await _salesCollection.UpdateOneAsync(filter, update);
            return;
        }

        public async Task DeleteAsync(int id) {
            FilterDefinition<Sales> filter = Builders<Sales>.Filter.Eq("_id", id);
            await _salesCollection.DeleteOneAsync(filter);
            return;
        }
    }
}
