using Microsoft.VisualStudio.TestTools.UnitTesting;
using QUEBB.Core.Boundary;
using QUEBB.Core.GetAllPosts;

namespace QUEBB.Core.Tests.GetAllPosts
{
    [TestClass]
    public class GetAllPostsHandlerTests
    {
        [TestMethod]
        public void CanCreateAddPostHandler()
        {
            var handler = CreateHandler();
            Assert.IsNotNull(handler);
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
