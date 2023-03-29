
using MediatR;
using Prueba.Domain.others;
using Prueba.Domain.Ports.DataAccess;

namespace Prueba.Application.UseCases
{
    public class GetUser
    {
        public record Dto(int Id, string FirstName, string LastName, string mail);


        public record Query(int Id) : IRequest<GetUser.Dto>;
        public class Handler : IRequestHandler<GetUser.Query, GetUser.Dto>
        {
            private readonly IApplicationUnitOfWork _UnitOfWork;
            


            public Handler(IApplicationUnitOfWork unitOfWork)
            {
                _UnitOfWork = unitOfWork;
               

            }

            public async Task<Dto> Handle(Query request, CancellationToken cancellationToken)
            {
                
                var ValidUser = await _UnitOfWork.Users.GetUser(request.Id);
                if (ValidUser is null) throw BusinessException.NotFoundWithMessage("No se ha encontrado un usuario con este id");
                return new Dto(ValidUser.Id, ValidUser.FirstName, ValidUser.LastName, ValidUser.Mail);
            }
        }




    }
}
