using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using DynamoDbService.Interfaces;

namespace DynamoDbService.DynamoServices
{
    public class DynamoDbContext<T> : DynamoDBContext, IDynamoDbContext<T>
    {
        public DynamoDbContext(IAmazonDynamoDB client) : base(client)
        {
        }

        public async Task<IEnumerable<T>> GetAsync(List<ScanCondition> conditions)
        {
            return await base.ScanAsync<T>(conditions).GetRemainingAsync();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await base.LoadAsync<T>(id);
        }

        public async Task DeleteByIdAsync(T item)
        {
            await base.DeleteAsync(item);
        }

        public async Task Save(T item)
        {
            await base.SaveAsync(item);
        }
    }
}
