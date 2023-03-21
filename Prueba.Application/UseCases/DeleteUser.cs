using FluentValidation;
using MediatR;
using Prueba.Domain.others;
using Prueba.Domain.Ports.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Application.UseCases
{
    public class DeleteUser
    {
        public record Command(int Id) : IRequest;
        public class Handler : IRequestHandler<Command>
        {
            private readonly IApplicationUnitOfWork _UnitOfWork;
            //private readonly IValidator<Command> validator;
            public Handler(IApplicationUnitOfWork unitOfWork)
            {
                _UnitOfWork = unitOfWork;
                //this.validator = validator;
            }

            async Task<Unit> IRequestHandler<Command, Unit>.Handle(Command request, CancellationToken cancellationToken)
            {
                var ValidUser = await _UnitOfWork.users.GetUser(request.Id);

                if (ValidUser == null) throw BusinessException.NotFoundWithMessage("No se ha encontrado un usuario con este id");

                _UnitOfWork.users.DeleteUser(ValidUser);

                return Unit.Value;
            }
            //public class Validator : AbstractValidator<Command>
            //{

            //    public Validator()
            //    {
            //        RuleFor(e => e.Id)
            //            .NotEmpty().WithMessage("Input mail vacio");

            //        RuleFor(e => e.FirstName)
            //            .NotEmpty().WithMessage("Input Nombre vacio");

            //        RuleFor(e => e.LastName).NotEmpty().WithMessage("Input Nombre vacio");
            //    }
            //}
        }
    }
}

