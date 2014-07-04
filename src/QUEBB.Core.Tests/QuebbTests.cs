using Microsoft.VisualStudio.TestTools.UnitTesting;
using QUEBB.Core.Boundary;

namespace QUEBB.Core.Tests
{
    [TestClass]
    public class QuebbTests
    {
        [TestMethod]
        public void CanCreateQuebb()
        {
            var quebb = new Quebb(new InMemoryRepository());
            Assert.IsNotNull(quebb);
        }
    }
}
