using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QUEBB.Core.Entities;

namespace QUEBB.Core.Tests.Entities
{
    [TestClass]
    public class PostTests
    {
        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        public void CloningANullPostThrowsArgumentNullException()
        {
            Post.Clone(null);
        }

        [TestClass]
        public class WhenAPostIsCloned
        {
            private Post _clonedPost;
            private const string ExpectedId = "ExpectedId";
            private const string ExpectedTitle = "The Expected Title";

            [TestInitialize]
            public void Setup()
            {
                var newPost = new Post
                {
                    Title = ExpectedTitle,
                    Id = ExpectedId
                };
                _clonedPost =Post.Clone(newPost);
            }

            [TestMethod]
            public void ThenDoesNotReturnNull()
            {
                Assert.IsNotNull(_clonedPost);
            }

            [TestMethod]
            public void ThenTitleMatchesExpectedTitle()
            {
                Assert.AreEqual(ExpectedTitle, _clonedPost.Title);
            }

            [TestMethod]
            public void ThenIdMatchesExpectedId()
            {
                Assert.AreEqual(ExpectedId, _clonedPost.Id);
            }
        }
    }
}