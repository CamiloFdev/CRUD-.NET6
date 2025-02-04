﻿using FluentValidation;
using MediatR;
using Prueba.Domain.AggregateRoots;
using Prueba.Domain.Ports.DataAccess;

namespace Prueba.Application.UseCases
{
    public class CreateUser
    {

        public record Command(string FirstName, string LastName, string mail) : IRequest;
        public class Handler : IRequestHandler<Command>
        {
            private readonly IApplicationUnitOfWork _UnitOfWork;
            private readonly IValidator<Command> validator;
            public Handler(IApplicationUnitOfWork unitOfWork, IValidator <Command> validator)
            {
                _UnitOfWork = unitOfWork;
                this.validator = validator;
            }
            public async Task <Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                validator.ValidateAndThrow(request);
                User user = new User(request.FirstName, request.LastName, request.mail);

                _UnitOfWork.Users.CreateUser(user);
                return Unit.Value;

            }


        }
        public class Validator : AbstractValidator<Command>{

            public Validator()
            {
                RuleFor(e => e.mail)
                    .EmailAddress().WithMessage("Formato de correo no valido")
                    .NotEmpty().WithMessage("Input mail vacio");

                RuleFor(e => e.FirstName)
                    .NotEmpty().WithMessage("Input Nombre vacio");

                RuleFor(e => e.LastName).NotEmpty().WithMessage("Input Nombre vacio");
            }
        }
    }

}
