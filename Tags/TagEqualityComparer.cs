using System.Diagnostics.CodeAnalysis;

namespace Tags;


public class TagEqualityComparer : IEqualityComparer<Tag>
{
    public bool Equals(Tag? x, Tag? y)
    {
        if (x is null || y is null)
            return false;

        return x.Id.Equals(y.Id);
    }

    public int GetHashCode([DisallowNull] Tag obj)
    {
        return obj.Id;
    }
}