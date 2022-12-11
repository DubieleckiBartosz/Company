namespace Company.API.Tools;

public static class TypeTools
{
    public static bool HasProperty(this Type obj, string propertyName)
    {
        return obj.GetProperty(propertyName) != null;
    }
}