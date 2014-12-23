using QUEBB.Core.AddPost;
using QUEBB.Core.Entities;
using QUEBB.Core.Infrastructure;
using Xunit;

namespace QUEBB.Core.Tests.AddPost.GivenAnAddPostHandler
{
    public class IfPassedANewPostWithAnId
    {
        private readonly AddPostHandler _handler;
        private readonly Post _newPost;

        public IfPassedANewPostWithAnId()
        {
            _handler = AddPostHandlerTests.CreateHandler();
            _newPost = AddPostHandlerTests.CreateValidPostForAdding();
            _newPost.Id = "ShouldNotHaveOne";
        }

        [Fact]
        public void ThenReturnsAPostThatHasTheSameTitle()
        {
            Assert.Throws<ValidationException>(() => _handler.Handle(new AddPostRequest(_newPost)));
        }
    }
}