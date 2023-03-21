using FluentValidation;
using MediatR;
using Prueba.Domain.AggregateRoots;
using Prueba.Domain.Ports.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Application.UseCases
{
    public class GetUser
    {
        public record Dto(User Users);


        public record Query(int Id) : IRequest<GetUser.Dto>;
        public class Handler : IRequestHandler<GetUser.Query, GetUser.Dto>
        {
            private readonly IApplicationUnitOfWork _UnitOfWork;
            //private readonly IValidator<Query> validator;


            public Handler(IApplicationUnitOfWork unitOfWork)
            {
                _UnitOfWork = unitOfWork;
                //this.validator = validator;

            }

            async Task<Dto>IRequestHandler<Query,Dto>.Handle(Query request, CancellationToken cancellationToken)
            {
                var users = await _UnitOfWork.users.GetUser(request.Id);

                return new Dto(users);
            }
        }




    }
}
