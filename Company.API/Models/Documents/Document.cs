using Company.API.Tools;
using MongoDB.Bson.Serialization.Attributes;

namespace Company.API.Models.Documents;

public abstract class Document : Base
{
    [BsonId(IdGenerator = typeof(DocumentIdGenerator))]
    public string Id { get; protected set; } 
}