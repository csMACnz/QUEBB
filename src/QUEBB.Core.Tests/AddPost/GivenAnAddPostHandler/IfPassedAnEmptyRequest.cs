using System;
using QUEBB.Core.AddPost;
using Xunit;

namespace QUEBB.Core.Tests.AddPost.GivenAnAddPostHandler
{
    public class IfPassedAnEmptyRequest
    {
        private AddPostHandler _handler;

        public IfPassedAnEmptyRequest()
        {
            _handler = AddPostHandlerTests.CreateHandler();
        }

        [Fact]
        public void ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(()=>_handler.Handle(null));
        }
    }
}