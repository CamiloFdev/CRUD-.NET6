using MediatR;
using Prueba.Domain.AggregateRoots;
using Prueba.Domain.Ports.DataAccess;


namespace Prueba.Application.UseCases
{
    public class ListUser
    {
        public record Dto(ICollection<User> Users);


        public record Query() : IRequest<ListUser.Dto>;
        public class Handler : IRequestHandler<ListUser.Query, ListUser.Dto>
        {
            private readonly IApplicationUnitOfWork _UnitOfWork;
        


            public Handler(IApplicationUnitOfWork unitOfWork)
            {
                _UnitOfWork = unitOfWork;
             

            }

             public async Task<Dto> Handle(Query request, CancellationToken cancellationToken)
            {
                var users = await _UnitOfWork.Users.ListUser();

                return new Dto(users);
            }
        }

    }
}