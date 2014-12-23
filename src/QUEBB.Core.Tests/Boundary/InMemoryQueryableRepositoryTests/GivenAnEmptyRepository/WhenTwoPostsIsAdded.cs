using QUEBB.Core.Boundary;

namespace QUEBB.Core.Tests.Boundary.InMemoryQueryableRepositoryTests.GivenAnEmptyRepository
{
    public class WhenTwoPostsIsAdded :
        CommonRepositoryTests.GivenAnEmptyRepository.WhenTwoPostsIsAdded
    {
        protected override IRepository CreateRepository()
        {
            return InMemoryQueryableRepositoryTests.CreateRepository();
        }
    }
}