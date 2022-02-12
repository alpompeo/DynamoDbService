using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;

namespace DynamoDbService.DynamoServices
{
    public class GuidTypeConverter : IPropertyConverter
    {
        public object FromEntry(DynamoDBEntry entry)
        {
            var primitive = entry as Primitive;

            if (primitive == null || !(primitive.Value is String) ||
                string.IsNullOrEmpty((string)primitive.Value) ||
                !Guid.TryParse((string)primitive.Value, out Guid guidValue))
                throw new ArgumentOutOfRangeException();

            return guidValue;
        }

        public DynamoDBEntry ToEntry(object value)
        {
            if (value == null || !(value is Guid)) throw new ArgumentOutOfRangeException();

            DynamoDBEntry entry = new Primitive
            {
                Value = ((Guid)value).ToString()
            };

            return entry;
        }
    }
}
