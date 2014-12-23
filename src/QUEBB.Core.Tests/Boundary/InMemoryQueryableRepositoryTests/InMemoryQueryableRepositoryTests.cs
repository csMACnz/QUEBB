using QUEBB.Core.Boundary;
using Xunit;

namespace QUEBB.Core.Tests.Boundary.InMemoryQueryableRepositoryTests
{
    public class InMemoryQueryableRepositoryTests
    {
        public static InMemoryQueryableRepository CreateRepository()
        {
            return new InMemoryQueryableRepository();
        }

        [Fact]
        public void CanCreateInMemoryQueryableRepository()
        {
            var repository = CreateRepository();
            Assert.NotNull(repository);
        }
    }
}
