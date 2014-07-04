using System;
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

        private static GetAllPostsHandler CreateHandler()
        {
            return CreateHandler(new InMemoryRepository());
        }

        private static GetAllPostsHandler CreateHandler(IRepository repository)
        {
            return new GetAllPostsHandler(repository);
        }

        public class GivenAGetAllPostsHandler
        {
            [TestClass]
            public class IfNotPassedARepository
            {
                [TestMethod]
                [ExpectedException(typeof (ArgumentNullException))]
                public void ThrowsArgumentNullException()
                {
                    CreateHandler(null);
                }
            }

            [TestClass]
            public class IfPassedAnEmptyRequest
            {
                private GetAllPostsHandler _handler;

                [TestInitialize]
                public void Setup()
                {
                    _handler = CreateHandler();
                }

                [TestMethod]
                [ExpectedException(typeof (ArgumentNullException))]
                public void ThrowsArgumentNullException()
                {
                    _handler.Handle(null);
                }
            }

            [TestClass]
            public class WhenRepositoryIsEmpty
            {
                private GetAllPostsHandler _handler;
                private GetAllPostsResponse _results;

                [TestInitialize]
                public void Setup()
                {
                    _handler = CreateHandler();
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
    }
}
