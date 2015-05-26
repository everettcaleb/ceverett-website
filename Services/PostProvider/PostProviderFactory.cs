
namespace CEverett.Services.PostProvider
{
    public static class PostProviderFactory
    {
        public static IPostProvider Create(object p)
        {
            return new LocalPostProvider();
        }
    }
}