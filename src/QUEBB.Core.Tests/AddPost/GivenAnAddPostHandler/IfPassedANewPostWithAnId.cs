using Microsoft.VisualStudio.TestTools.UnitTesting;
using QUEBB.Core.AddPost;
using QUEBB.Core.Entities;
using QUEBB.Core.Infrastructure;

namespace QUEBB.Core.Tests.AddPost.GivenAnAddPostHandler
{
    [TestClass]
    public class IfPassedANewPostWithAnId
    {
        private AddPostHandler _handler;
        private Post _newPost;

        [TestInitialize]
        public void Setup()
        {
            _handler = AddPostHandlerTests.CreateHandler();
            _newPost = AddPostHandlerTests.CreateValidPostForAdding();
            _newPost.Id = "ShouldNotHaveOne";
        }

        [TestMethod]
        [ExpectedException(typeof (ValidationException))]
        public void ThenReturnsAPostThatHasTheSameTitle()
        {
            _handler.Handle(new AddPostRequest(_newPost));
        }
    }
}