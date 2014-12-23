using QUEBB.Core.AddPost;
using QUEBB.Core.Entities;
using Xunit;

namespace QUEBB.Core.Tests.AddPost.GivenAnAddPostHandler
{
    public class IfPassedANewPostWithATitle
    {
        private const string Title = "My Post Title";

        private readonly AddPostResponse _response;
        private readonly Post _newPost;

        public IfPassedANewPostWithATitle()
        {
            _newPost = AddPostHandlerTests.CreateValidPostForAdding();
            _newPost.Title = Title;

            AddPostHandler handler = AddPostHandlerTests.CreateHandler();
            _response = handler.Handle(new AddPostRequest(_newPost));
        }

        [Fact]
        public void ThenReturnsAPostThatHasTheSameTitle()
        {
            Assert.Equal(_newPost.Title, _response.Post.Title);
        }
    }
}