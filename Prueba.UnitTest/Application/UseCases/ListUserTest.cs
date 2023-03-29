using Prueba.Application.UseCases;
using Prueba.Domain.Ports.DataAccess;
using Moq;
using Prueba.Domain.AggregateRoots;
using System.Collections.ObjectModel;


namespace Prueba.UnitTest.Application.UseCases
{
    public class ListUserTest
    {
        [Fact]
        public async Task ListUser_ShouldReturnCollection_WhenUsersExists()
        {
            //arrangue
            const int id = 1;
            var query = new ListUser.Query();

            var unitOfWork = Mock.Of<IApplicationUnitOfWork>();
            var unitOfWorkMock = Mock.Get(unitOfWork);

            ICollection<User> returnedListUser = new Collection<User> { };
            var ListUser = new User("Fabian", "contreras", "mail@mail.cl");
            returnedListUser.Add(ListUser);
            unitOfWorkMock.Setup(e => e.Users.ListUser()).Returns(Task.FromResult(returnedListUser));

            var handler = new ListUser.Handler(unitOfWork);

            //act

            var dto = await handler.Handle(query, default);

            //assert


            //
        }
    }   
}
