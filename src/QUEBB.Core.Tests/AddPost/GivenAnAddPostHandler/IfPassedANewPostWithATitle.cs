using Microsoft.VisualStudio.TestTools.UnitTesting;
using QUEBB.Core.AddPost;
using QUEBB.Core.Entities;

namespace QUEBB.Core.Tests.AddPost.GivenAnAddPostHandler
{
    [TestClass]
    public class IfPassedANewPostWithATitle
    {
        private const string Title = "My Post Title";

        private AddPostResponse _response;
        private AddPostHandler _handler;
        private Post _newPost;

        [TestInitialize]
        public void Setup()
        {
            _handler = AddPostHandlerTests.CreateHandler();
            _newPost = AddPostHandlerTests.CreateValidPostForAdding();
            _newPost.Title = Title;
            _response = _handler.Handle(new AddPostRequest(_newPost));
        }

        [TestMethod]
        public void ThenReturnsAPostThatHasTheSameTitle()
        {
            Assert.AreEqual(_newPost.Title, _response.Post.Title);
        }
    }
}