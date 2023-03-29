using Prueba.Application.UseCases;
using Prueba.Domain.Ports.DataAccess;
using Moq;
using Prueba.Domain.AggregateRoots;
using FluentAssertions;
using Prueba.Domain.others;
using System.Net;

namespace Prueba.UnitTest.Application.UseCases
{
    public class GetUserTest
    {
        [Fact] 
        public async Task GetUser_ShouldReturnDto_WhenUserExist()
        {
            //arrangue
            const int id = 1;
            var query = new GetUser.Query(id);

            var unitOfWork = Mock.Of<IApplicationUnitOfWork>();
            var unitOfWorkMock = Mock.Get(unitOfWork);
            var returnedUser = new User(id,"Fabian","contreras","mail@mail.cl");
            unitOfWorkMock.Setup(e => e.Users.GetUser(id)).Returns(Task.FromResult(returnedUser));

            var  handler = new GetUser.Handler(unitOfWork);

            //act

            var dto = await handler.Handle(query, default);

            //assert

            dto.Id.Should().Be(id);
            dto.FirstName.Should().Be(returnedUser.FirstName);
            dto.LastName.Should().Be(returnedUser.LastName);
            dto.mail.Should().Be(returnedUser.Mail);

            //
        }
        [Fact]
        public async Task GetUser_ShouldThrowBusinessException_WhenUserDoesntExist() 
        {

            //arrangue
            const int id = 1;

            var query = new GetUser.Query(id);
            var unitOfWork = Mock.Of<IApplicationUnitOfWork>();
            var unitOfWorkMock = Mock.Get(unitOfWork);
            unitOfWorkMock.Setup(e => e.Users.GetUser(It.IsAny<int>())).Returns(Task.FromResult<User>(null));
            var handler = new GetUser.Handler(unitOfWork);

            //act

            var act = ()=> handler.Handle(query, default);

            //assert

            (await act.Should().ThrowExactlyAsync<BusinessException>())
             .And.StatusCodeNumber.Should().Be((int)HttpStatusCode.NotFound);

        }
    }
}
