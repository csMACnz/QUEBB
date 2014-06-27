using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QUEBB.Core.AddPost;
using QUEBB.Core.Entities;

namespace QUEBB.Core.Tests.AddPost
{
    [TestClass]
    public class AddPostTest
    {
        [TestMethod]
        public void CanCreateAddPostHandler()
        {
            var handler = CreateHandler();
            Assert.IsNotNull(handler);
        }

        private static AddPostHandler CreateHandler()
        {
            return new AddPostHandler();
        }

        public class GivenAnAddPostHandler
        {
            [TestClass]
            public class IfPassedAnEmptyRequest
            {
                private AddPostHandler _handler;

                [TestInitialize]
                public void Setup()
                {
                    _handler = CreateHandler();
                }

                [TestMethod]
                [ExpectedException(typeof(ArgumentNullException))]
                public void ThrowsArgumentNullException()
                {
                    _handler.Handle(null);
                }
            }

            [TestClass]
            public class IfPassedANewPost
            {
                private AddPostResponse _response;
                private AddPostHandler _handler;
                private NewPost _newPost;

                [TestInitialize]
                public void Setup()
                {
                    _handler = CreateHandler();
                    _newPost = new NewPost();
                    _response = _handler.Handle(new AddPostRequest(_newPost));
                }

                [TestMethod]
                public void ThenReturnsSuccessfully()
                {
                    Assert.IsNotNull(_response);
                }

                [TestMethod]
                public void ThenReturnsANewId()
                {
                    Assert.IsTrue(_response.Post.Id > 0);
                }

                [TestMethod]
                public void ThenReturnsAPostThatIsReferentiallyDifferent()
                {
                    Assert.AreNotEqual(_newPost, _response);
                }
            }

            [TestClass]
            public class IfPassedANewPostWithATitle
            {
                private const string Title = "My Post Title";

                private AddPostResponse _response;
                private AddPostHandler _handler;
                private NewPost _newPost;

                [TestInitialize]
                public void Setup()
                {
                    _handler = CreateHandler();
                    _newPost = new NewPost {Title = Title};
                    _response = _handler.Handle(new AddPostRequest(_newPost));
                }

                [TestMethod]
                public void ThenReturnsAPostThatHasTheSameTitle()
                {
                    Assert.AreEqual(_newPost.Title, _response.Post.Title);
                }
            }
        }
    }
}