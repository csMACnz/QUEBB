using Microsoft.VisualStudio.TestTools.UnitTesting;
using QUEBB.Core.GetAllPosts;

namespace QUEBB.Core.Tests.GetAllPosts.GivenAGetAllPostsHandler
{
    [TestClass]
    public class WhenRepositoryIsEmpty
    {
        private GetAllPostsHandler _handler;
        private GetAllPostsResponse _results;

        [TestInitialize]
        public void Setup()
        {
            _handler = GetAllPostsHandlerTests.CreateHandler();
            _results = _handler.Handle(new GetAllPostsRequest());
        }

        [TestMethod]
        public void ReturnsSuccessfully()
        {
            Assert.IsNotNull(_results);
        }

        [TestMethod]
        public void ReturnedPostsIsNotNull()
        {
            Assert.IsNotNull(_results.Posts);
        }

        [TestMethod]
        public void ReturnsNoItems()
        {
            Assert.AreEqual(0, _results.Posts.Count);
        }
    }

}