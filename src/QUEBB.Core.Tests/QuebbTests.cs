using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace QUEBB.Core.Tests
{
    [TestClass]
    public class QuebbTests
    {
        [TestMethod]
        public void CanCreateQuebb()
        {
            var quebb = new Quebb();
            Assert.IsNotNull(quebb);
        }
    }
}
