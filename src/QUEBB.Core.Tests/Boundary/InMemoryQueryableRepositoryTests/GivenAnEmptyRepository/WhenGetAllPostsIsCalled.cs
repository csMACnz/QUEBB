using QUEBB.Core.Boundary;

namespace QUEBB.Core.Tests.Boundary.InMemoryQueryableRepositoryTests.GivenAnEmptyRepository
{
    public class WhenGetAllPostsIsCalled :
        CommonRepositoryTests.GivenAnEmptyRepository.WhenGetAllPostsIsCalled
    {
        protected override IRepository CreateRepository()
        {
            return InMemoryQueryableRepositoryTests.CreateRepository();
        }
    }
}