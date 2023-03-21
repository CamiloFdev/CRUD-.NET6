using FluentValidation;
using MediatR;
using Prueba.Domain.AggregateRoots;
using Prueba.Domain.Ports.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Application.UseCases
{
    public class ListUser
    {
        public record Dto(ICollection<User> Users);


        public record Query() : IRequest<ListUser.Dto>;
        public class Handler : IRequestHandler<ListUser.Query, ListUser.Dto>
        {
            private readonly IApplicationUnitOfWork _UnitOfWork;
            private readonly IValidator<Query> validator;


            public Handler(IApplicationUnitOfWork unitOfWork)
            {
                _UnitOfWork = unitOfWork;
                //this.validator = validator;

            }

            async Task<Dto> IRequestHandler<Query, Dto>.Handle(Query request, CancellationToken cancellationToken)
            {
                var users = await _UnitOfWork.users.ListUser();

                return new Dto(users);
            }
        }

    }
}