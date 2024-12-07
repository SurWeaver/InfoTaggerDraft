namespace Tags;


public class TagList : ITagList
{
    private readonly Dictionary<int, Tag> tags = new();


    public void AddTag(Tag tag)
    {
        if (tags.ContainsKey(tag.Id))
            throw new Exception("Tag already exists.");

        tags.Add(tag.Id, tag);
    }

    public Tag? GetTag(int id)
    {
        tags.TryGetValue(id, out Tag? actualTag);
        return actualTag;
    }

    public void RemoveTag(int id)
    {
        tags.Remove(id);
    }

    public void RemoveTag(Tag tag)
    {
        tags.Remove(tag.Id);
    }
}


public interface ITagList
{
    public void AddTag(Tag tag);
    public Tag? GetTag(int id);

    public void RemoveTag(int id);
    public void RemoveTag(Tag tag);
}
