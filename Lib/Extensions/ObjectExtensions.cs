namespace Playground.Lib.Extensions
{
    public static class ObjectExtensions
    {
        extension(object? obj)
        {
            public string? ToLowerString()
            {
                return obj?.ToString()?.ToLower();
            }
            public int? ToInt()
            {
                return obj switch
                {
                    int i => i,
                    _ => null
                };
            }
        }
    }
}
