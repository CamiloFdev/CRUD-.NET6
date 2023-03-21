using FluentValidation;
using MediatR;
using Prueba.Domain.AggregateRoots;
using Prueba.Domain.Ports.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prueba.Domain.others;
namespace Prueba.Application.UseCases
{
    public class UpdateUser
    {
        
        public record Command(int Id, string FirstName, string LastName, string mail) : IRequest;
        public class Handler : IRequestHandler<Command>
        {
            private readonly IApplicationUnitOfWork _UnitOfWork;
            private readonly IValidator<Command> validator;
            public Handler(IApplicationUnitOfWork unitOfWork, IValidator<Command> validator)
            {
                _UnitOfWork = unitOfWork;
                this.validator = validator;
            }

            async Task<Unit> IRequestHandler<Command, Unit>.Handle(Command request, CancellationToken cancellationToken)
            {
                var ValidUser = await _UnitOfWork.users.GetUser(request.Id);

                if (ValidUser is null) throw BusinessException.NotFoundWithMessage("No se ha encontrado un usuario con este id");

                 ValidUser = ValidUser.UpdateState(request.Id, request.FirstName, request.LastName, request.mail, ValidUser);
               

                _UnitOfWork.users.UpdateUser(ValidUser);

                return Unit.Value;
            }
            public class Validator : AbstractValidator<Command>
            {

                public Validator()
                {
                    RuleFor(e => e.Id)
                        .NotEmpty().WithMessage("Input mail vacio");

                    RuleFor(e => e.FirstName)
                        .NotEmpty().WithMessage("Input Nombre vacio");

                    RuleFor(e => e.LastName).NotEmpty().WithMessage("Input Nombre vacio");
                }
            }
        }
    }
}