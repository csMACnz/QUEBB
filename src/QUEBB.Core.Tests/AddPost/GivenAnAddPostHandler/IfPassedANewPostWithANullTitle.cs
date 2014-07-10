using Microsoft.VisualStudio.TestTools.UnitTesting;
using QUEBB.Core.AddPost;
using QUEBB.Core.Entities;
using QUEBB.Core.Infrastructure;

namespace QUEBB.Core.Tests.AddPost.GivenAnAddPostHandler
{
    [TestClass]
    public class IfPassedANewPostWithANullTitle
    {
        private AddPostHandler _handler;
        private Post _newPost;

        [TestInitialize]
        public void Setup()
        {
            _handler = AddPostHandlerTests.CreateHandler();
            _newPost = AddPostHandlerTests.CreateValidPostForAdding();
            _newPost.Title = null;

        }

        [TestMethod]
        [ExpectedException(typeof (ValidationException))]
        public void ThenThrowsAValidationException()
        {
            _handler.Handle(new AddPostRequest(_newPost));
        }
    }
}