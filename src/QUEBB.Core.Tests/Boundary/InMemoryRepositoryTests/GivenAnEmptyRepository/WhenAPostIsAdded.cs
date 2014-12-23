using QUEBB.Core.Boundary;

namespace QUEBB.Core.Tests.Boundary.InMemoryRepositoryTests.GivenAnEmptyRepository
{
    public class WhenAPostIsAdded :
        CommonRepositoryTests.GivenAnEmptyRepository.WhenAPostIsAdded
    {
        protected override IRepository CreateRepository()
        {
            return InMemoryRepositoryTests.CreateRepository();
        }
    }
}