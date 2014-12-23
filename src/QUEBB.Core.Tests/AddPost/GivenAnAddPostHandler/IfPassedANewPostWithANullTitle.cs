using QUEBB.Core.AddPost;
using QUEBB.Core.Entities;
using QUEBB.Core.Infrastructure;
using Xunit;

namespace QUEBB.Core.Tests.AddPost.GivenAnAddPostHandler
{
    public class IfPassedANewPostWithANullTitle
    {
        private readonly AddPostHandler _handler;
        private readonly Post _newPost;

        public IfPassedANewPostWithANullTitle()
        {
            _handler = AddPostHandlerTests.CreateHandler();
            _newPost = AddPostHandlerTests.CreateValidPostForAdding();
            _newPost.Title = null;

        }

        [Fact]
        public void ThenThrowsAValidationException()
        {
            Assert.Throws<ValidationException>(() => _handler.Handle(new AddPostRequest(_newPost)));
        }
    }
}