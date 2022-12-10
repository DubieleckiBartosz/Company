namespace Company.API.Options;

public class MongoConnections
{
    public bool IsActive { get; set; }
    public string DatabaseName { get; set; }
    public string ConnectionString { get; set; } 
}