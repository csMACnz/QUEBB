using QUEBB.Core.AddPost;
using QUEBB.Core.Boundary;
using QUEBB.Core.Entities;
using Xunit;

namespace QUEBB.Core.Tests.AddPost
{
    public class AddPostHandlerTests
    {
        [Fact]
        public void CanCreateAddPostHandler()
        {
            var handler = CreateHandler();
            Assert.NotNull(handler);
        }

        public static AddPostHandler CreateHandler()
        {
            return new AddPostHandler(new InMemoryRepository());
        }

        public static AddPostHandler CreateHandler(IRepository repository)
        {
            return new AddPostHandler(repository);
        }

        public static Post CreateValidPostForAdding()
        {
            return new Post
            {
                Id = null,
                Title = "Valid Post Title"
            };
        }
    }
}