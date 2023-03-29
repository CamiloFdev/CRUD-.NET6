using FluentValidation;
using MediatR;
using Prueba.Domain.others;
using Prueba.Domain.Ports.DataAccess;


namespace Prueba.Application.UseCases
{
    public class DeleteUser
    {
        public record Command(int Id) : IRequest;
        public class Handler : IRequestHandler<Command>
        {
            private readonly IApplicationUnitOfWork _UnitOfWork;
            private readonly IValidator<Command> validator;
            public Handler(IApplicationUnitOfWork unitOfWork, IValidator<Command> validator)
            {
                _UnitOfWork = unitOfWork;
                this.validator = validator;
            }
            

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var ValidUser = await _UnitOfWork.Users.GetUser(request.Id);

                if (ValidUser == null) throw BusinessException.NotFoundWithMessage("No se ha encontrado un usuario con este id");

                _UnitOfWork.Users.DeleteUser(ValidUser);

                return Unit.Value;
            }

        }
        public class Validator : AbstractValidator<Command>
        {

            public Validator()
            {
                RuleFor(e => e.Id)
                    .NotEmpty().WithMessage("Input id vacio");


            }
        }
    }
}

