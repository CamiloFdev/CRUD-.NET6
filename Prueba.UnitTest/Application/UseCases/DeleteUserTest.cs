using Moq;
using Prueba.Application.UseCases;
using Prueba.Domain.AggregateRoots;
using Prueba.Domain.Ports.DataAccess;


namespace Prueba.UnitTest.Application.UseCases
{
    public class DeleteUserTest
    {
        [Fact]
        public async Task DeleteUser_ShouldDeleteUser_WhenUserIsDeleted()
        {
            //arrangue
            const int id = 1;

            var command = new DeleteUser.Command(id);

            var unitOfWork = Mock.Of<IApplicationUnitOfWork>();
            var unitOfWorkMock = Mock.Get(unitOfWork);
            var deleteUser = new User("Fabian", "contreras", "mail@mail.cl");
            unitOfWorkMock.Setup(e => e.Users.GetUser(id)).Returns(Task.FromResult(deleteUser));
            unitOfWorkMock.Setup(e => e.Users.DeleteUser(deleteUser));
            var validate = new DeleteUser.Validator();
            var handler = new DeleteUser.Handler(unitOfWork,validate);

            //actz

            var unit = await handler.Handle(command, default);

            //assert

            //
        }
    }
}
