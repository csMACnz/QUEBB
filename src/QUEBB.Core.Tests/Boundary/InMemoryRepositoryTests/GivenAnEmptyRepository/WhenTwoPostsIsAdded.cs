using QUEBB.Core.Boundary;

namespace QUEBB.Core.Tests.Boundary.InMemoryRepositoryTests.GivenAnEmptyRepository
{
    public class WhenTwoPostsIsAdded : CommonRepositoryTests.GivenAnEmptyRepository.WhenTwoPostsIsAdded
    {
        protected override IRepository CreateRepository()
        {
            return InMemoryRepositoryTests.CreateRepository();
        }
    }
}