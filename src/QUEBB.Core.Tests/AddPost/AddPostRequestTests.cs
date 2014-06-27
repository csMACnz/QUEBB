using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QUEBB.Core.AddPost;

namespace QUEBB.Core.Tests.AddPost
{
    [TestClass]
    public class AddPostRequestTests
    {
        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        public void IfPassedAnNullNewPostThrowsArgumentNullException()
        {
            new AddPostRequest(null);
        }
    }
}
