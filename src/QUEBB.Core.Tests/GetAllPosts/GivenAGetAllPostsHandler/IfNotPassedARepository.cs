using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace QUEBB.Core.Tests.GetAllPosts.GivenAGetAllPostsHandler
{
    [TestClass]
    public class IfNotPassedARepository
    {
        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        public void ThrowsArgumentNullException()
        {
            GetAllPostsHandlerTests.CreateHandler(null);
        }
    }
}