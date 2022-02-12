using Amazon.DynamoDBv2.DataModel;

namespace DynamoDbService.Interfaces
{
    public interface IDynamoDbContext<T>
    {
        Task<IEnumerable<T>> GetAsync(List<ScanCondition> conditions);
        Task<T> GetByIdAsync(string id);
        Task Save(T item);
        Task DeleteByIdAsync(T item);
    }
}