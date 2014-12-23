using QUEBB.Core.Boundary;
using Xunit;

namespace QUEBB.Core.Tests
{
    public class QuebbTests
    {
        [Fact]
        public void CanCreateQuebb()
        {
            var quebb = new Quebb(new InMemoryRepository());
            Assert.NotNull(quebb);
        }
    }
}
