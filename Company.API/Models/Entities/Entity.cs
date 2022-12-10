namespace Company.API.Models.Entities;

public abstract class Entity
{
    public Guid Id { get; private set; }
    public DateTime Created { get; set; }
    public DateTime Modified { get; set; }
    public DateTime? Deleted { get; set; }

    protected Entity()
    {
        Id = Guid.NewGuid();
        Created = DateTime.UtcNow;
        Modified = Created;
        Deleted = null;
    }
}