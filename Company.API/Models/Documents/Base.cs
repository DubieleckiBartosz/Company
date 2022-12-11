namespace Company.API.Models.Documents;

public abstract class Base
{
    public DateTime Created { get; private set; }
    public DateTime Modified { get; private set; }
    public DateTime? Deleted { get; private set; }
    protected Base()
    {
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