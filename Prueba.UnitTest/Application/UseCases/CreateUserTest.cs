using Prueba.Application.UseCases;
using Prueba.Domain.Ports.DataAccess;
using Moq;
using Prueba.Domain.AggregateRoots;


namespace Prueba.UnitTest.Application.UseCases
{
    public class CreateUserTest
    {
        [Fact]
        public async Task CreateUser_ShouldCreateUser_WhenUserIsCreated()
        {
            //arrangue
            const int id = 1;
            
            var command = new CreateUser.Command("Fabian","contreras","mail@mail.cl");
            
            var unitOfWork = Mock.Of<IApplicationUnitOfWork>();
            var unitOfWorkMock = Mock.Get(unitOfWork);
            var createUser = new User("Fabian", "contreras", "mail@mail.cl");
            unitOfWorkMock.Setup(e => e.Users.CreateUser(createUser));
            var validate = new CreateUser.Validator();
            var handler = new CreateUser.Handler(unitOfWork,validate);

            //act

            var unit = await handler.Handle(command,default);

            //assert

            //
        }


    }
}
