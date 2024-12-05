

namespace Tags;

public static class TagIdGenerator
{
    private static int freeId = 0;

    public static int GetId()
    {
        return freeId++;
    }
}
