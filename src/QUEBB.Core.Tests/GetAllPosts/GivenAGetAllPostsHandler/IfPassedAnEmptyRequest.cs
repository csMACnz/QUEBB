using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QUEBB.Core.GetAllPosts;

namespace QUEBB.Core.Tests.GetAllPosts.GivenAGetAllPostsHandler
{
    [TestClass]
    public class IfPassedAnEmptyRequest
    {
        private GetAllPostsHandler _handler;

        [TestInitialize]
        public void Setup()
        {
            _handler = GetAllPostsHandlerTests.CreateHandler();
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        public void ThrowsArgumentNullException()
        {
            _handler.Handle(null);
        }
    }
}