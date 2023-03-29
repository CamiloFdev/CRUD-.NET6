using Moq;
using Prueba.Application.UseCases;
using Prueba.Domain.AggregateRoots;
using Prueba.Domain.Ports.DataAccess;


namespace Prueba.UnitTest.Application.UseCases
{
    public class UpdateUserTest
    {
        [Fact]
        public async Task CreateUser_ShouldCreateUser_WhenUserIsCreated()
        {
            //arrangue
            const int id = 1;

            var command = new UpdateUser.Command(id,"Fabian", "contreras", "mail@mail.cl");

            var unitOfWork = Mock.Of<IApplicationUnitOfWork>();
            var unitOfWorkMock = Mock.Get(unitOfWork);
            var updateUser = new User("Fabian", "contreras", "mail@mail.cl");
            unitOfWorkMock.Setup(e => e.Users.GetUser(id)).Returns(Task.FromResult(updateUser));
            unitOfWorkMock.Setup(e => e.Users.UpdateUser(updateUser));
            var validate = new UpdateUser.Validator();
            var handler = new UpdateUser.Handler(unitOfWork,validate);

            //actz

            var unit = await handler.Handle(command,default);

            //assert

            //
        }
    }
}
