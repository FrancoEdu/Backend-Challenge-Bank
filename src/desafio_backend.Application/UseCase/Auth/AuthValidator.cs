using desafio_backend.Communication.Requests.Auth;
using desafio_backend.Exception;
using FluentValidation;

namespace desafio_backend.Application.UseCase.Auth;
public class AuthValidator : AbstractValidator<AuthLoginRequest>
{
    public AuthValidator()
    {
        RuleFor(x => x.Email).NotEmpty().WithMessage(ResourceErrorMessage.EMAIL_REQUIRED).EmailAddress().WithMessage(ResourceErrorMessage.EMAIL_INVALID);
        RuleFor(x => x.Password).NotEmpty().WithMessage(ResourceErrorMessage.PWD_REQUIRED)
            .MinimumLength(8).WithMessage(ResourceErrorMessage.PWD_MINIMUN_LENGTH)
            .MaximumLength(16).WithMessage(ResourceErrorMessage.PWD_EXCEED_MAX)
            .Matches(@"[A-Z]+").WithMessage(ResourceErrorMessage.PWD_NOT_CONTAIN_UP_LETTER)
            .Matches(@"[a-z]+").WithMessage(ResourceErrorMessage.PWD_NOT_CONTAIN_LOW_LETTER)
            .Matches(@"[0-9]+").WithMessage(ResourceErrorMessage.PWD_NOT_CONTAIN_NUMBER)
            .Matches(@"[\!\?\*\.]+").WithMessage(ResourceErrorMessage.PWD_NOT_CONTAIN_LEAST);
    }
}
