namespace Company.API.Models.Entities;

public abstract class Entity
{
    public Guid Id { get; private set; }
    public DateTime Created { get; private set; }
    public DateTime Modified { get; private set; }
    public DateTime? Deleted { get; private set; }

    protected Entity()
    {
        Id = Guid.NewGuid();
        Created = DateTime.UtcNow;
        Modified = Created;
        Deleted = null;
    }

    public void SetModify()
    {
        Modified = DateTime.UtcNow;
    }

    public void SetDelete()
    {
        Deleted = DateTime.UtcNow;
    }
}