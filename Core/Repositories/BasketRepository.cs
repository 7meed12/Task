using Core.InterFaces;
using Models;
using StackExchange.Redis;
using System.Text.Json;

namespace Core.Repositories
{
    public class BasketRepository : IBasketRepository
    {
         private readonly IDatabase _database;
        public BasketRepository(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }

        public async Task<bool> DeleteBasketAsync(string id)
        {
            return await _database.KeyDeleteAsync(id); 
        }

        public async Task<CustomerBasket> GetBasketAsync(string id)
        {
            var data = await _database.StringGetAsync(id);
            return data.IsNullOrEmpty ?  null : JsonSerializer.Deserialize<CustomerBasket>(data);
        }

        public async Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket)
        {
            var created = await _database.StringSetAsync(basket.Id, JsonSerializer.Serialize(basket)
                ,TimeSpan.FromDays(10));
            if (!created) return null;
            return await GetBasketAsync(basket.Id);

        }
    }
}
