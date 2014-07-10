using Microsoft.VisualStudio.TestTools.UnitTesting;
using QUEBB.Core.AddPost;
using QUEBB.Core.Boundary;
using QUEBB.Core.Entities;

namespace QUEBB.Core.Tests.AddPost
{
    [TestClass]
    public class AddPostHandlerTests
    {
        [TestMethod]
        public void CanCreateAddPostHandler()
        {
            var handler = CreateHandler();
            Assert.IsNotNull(handler);
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