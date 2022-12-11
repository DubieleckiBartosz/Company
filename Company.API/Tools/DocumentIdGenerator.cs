using MongoDB.Bson.Serialization;

namespace Company.API.Tools;

public class DocumentIdGenerator : IIdGenerator
{
    public object GenerateId(object container, object document)
    {
        return "Doc_" + Guid.NewGuid().ToString();
    }

    public bool IsEmpty(object id)
    {
        return string.IsNullOrEmpty(id?.ToString());
    }
}