using System;
using QUEBB.Core.GetAllPosts;
using Xunit;

namespace QUEBB.Core.Tests.GetAllPosts.GivenAGetAllPostsHandler
{
    public class IfPassedAnEmptyRequest
    {
        private GetAllPostsHandler _handler;

        public IfPassedAnEmptyRequest()
        {
            _handler = GetAllPostsHandlerTests.CreateHandler();
        }

        [Fact]
        public void ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _handler.Handle(null));
        }
    }
}