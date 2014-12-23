using QUEBB.Core.GetAllPosts;
using Xunit;

namespace QUEBB.Core.Tests.GetAllPosts.GivenAGetAllPostsHandler
{
    public class WhenRepositoryIsEmpty
    {
        private readonly GetAllPostsResponse _results;

        public WhenRepositoryIsEmpty()
        {
            GetAllPostsHandler handler = GetAllPostsHandlerTests.CreateHandler();
            _results = handler.Handle(new GetAllPostsRequest());
        }

        [Fact]
        public void ReturnsSuccessfully()
        {
            Assert.NotNull(_results);
        }

        [Fact]
        public void ReturnedPostsIsNotNull()
        {
            Assert.NotNull(_results.Posts);
        }

        [Fact]
        public void ReturnsNoItems()
        {
            Assert.Equal(0, _results.Posts.Count);
        }
    }

}