using desafio_backend.Communication.Requests.Transfers;
using desafio_backend.Exception;
using FluentValidation;

namespace desafio_backend.Application.UseCase.Transfers;
public class TransferValidator : AbstractValidator<TransferRequest>
{
    public TransferValidator()
    {
        RuleFor(x => x.Payee).NotEmpty().WithMessage(ResourceErrorMessage.PAYEE_ID_REQUIRED);
        RuleFor(x => x.Value).NotEmpty().WithMessage(ResourceErrorMessage.TRANSFERR_VALUE).GreaterThan(0).WithMessage(ResourceErrorMessage.VALUE_GREATHER_THAN_ZERO);
    }
}
