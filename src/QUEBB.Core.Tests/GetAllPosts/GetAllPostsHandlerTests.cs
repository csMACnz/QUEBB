using QUEBB.Core.Boundary;
using QUEBB.Core.GetAllPosts;
using Xunit;

namespace QUEBB.Core.Tests.GetAllPosts
{
    public class GetAllPostsHandlerTests
    {
        [Fact]
        public void CanCreateAddPostHandler()
        {
            var handler = CreateHandler();
            Assert.NotNull(handler);
        }

        public static GetAllPostsHandler CreateHandler()
        {
            return CreateHandler(new InMemoryRepository());
        }

        public static GetAllPostsHandler CreateHandler(IRepository repository)
        {
            return new GetAllPostsHandler(repository);
        }
    }
}
