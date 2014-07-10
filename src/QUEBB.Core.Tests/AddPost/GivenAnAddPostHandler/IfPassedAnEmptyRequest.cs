using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QUEBB.Core.AddPost;

namespace QUEBB.Core.Tests.AddPost.GivenAnAddPostHandler
{
    [TestClass]
    public class IfPassedAnEmptyRequest
    {
        private AddPostHandler _handler;

        [TestInitialize]
        public void Setup()
        {
            _handler = AddPostHandlerTests.CreateHandler();
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        public void ThrowsArgumentNullException()
        {
            _handler.Handle(null);
        }
    }
}