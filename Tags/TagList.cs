namespace Tags;


public class TagList : ITagList
{
    private readonly HashSet<Tag> tags = new(new TagEqualityComparer());


    public void AddTag(Tag tag)
    {
        if (tags.Contains(tag))
            throw new Exception("Tag already exists.");

        tags.Add(tag);
    }

    public Tag? GetTag(int id)
    {
        tags.TryGetValue(Tag.ComparisonTag(id), out Tag? actualTag);
        return actualTag;
    }

    public void RemoveTag(int id)
    {
        tags.Remove(Tag.ComparisonTag(id));
    }

    public void RemoveTag(Tag tag)
    {
        tags.Remove(tag);
    }
}


public interface ITagList
{
    public void AddTag(Tag tag);
    public Tag? GetTag(int id);

    public void RemoveTag(int id);
    public void RemoveTag(Tag tag);
}
