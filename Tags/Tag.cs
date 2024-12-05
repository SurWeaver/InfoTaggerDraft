namespace Tags;

public class Tag
{
    public int Id { get; init; }
    public int? ParentId { get; set; }

    public string Name { get; set; }
    public string? ShortName { get; set; }


    private Tag(string name, string? shortName = null)
    {
        Name = name;
        ShortName = shortName;
    }


    public static Tag NewTag(string name, string? shortName = null)
    {
        return new Tag(name, shortName)
        {
            Id = TagIdGenerator.GetId()
        };
    }

    public static Tag ComparisonTag(int id) => new Tag(string.Empty) { Id = id };


    public override string ToString()
    {
        return $"Tag: n: {Name}; sn: {ShortName}; id: {Id}; pId: {ParentId};";
    }
}
