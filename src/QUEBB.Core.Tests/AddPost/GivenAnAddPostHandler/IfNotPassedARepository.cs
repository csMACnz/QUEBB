using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace QUEBB.Core.Tests.AddPost.GivenAnAddPostHandler
{
    [TestClass]
    public class IfNotPassedARepository
    {
        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        public void ThrowsArgumentNullException()
        {
            AddPostHandlerTests.CreateHandler(null);
        }
    }
}