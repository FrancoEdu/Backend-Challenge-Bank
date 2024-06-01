using AutoMapper;
using desafio_backend.Communication.Requests.Auth;
using desafio_backend.Communication.Response.Token;
using desafio_backend.Domain.Repositories.Auth;
using desafio_backend.Domain.Repositories.Users;
using desafio_backend.Exception;
using desafio_backend.Exception.ExceptionBase;
using System.Security.Cryptography;

namespace desafio_backend.Application.UseCase.Auth;
public class AuthUseCase : IAuthUseCase
{
    private readonly IUserReadOnlyRepository _userReadOnlyRepository;
    private readonly IAuthRepository _authRepository;

    public AuthUseCase(IUserReadOnlyRepository userReadOnlyRepository, IAuthRepository authRepository, IMapper mapper)
    {
        _userReadOnlyRepository = userReadOnlyRepository;
        _authRepository = authRepository;
    }

    public async Task<TokenResponse> Authenticate(AuthLoginRequest request)
    {
        Validate(request);

        var userExists = await _userReadOnlyRepository.GetByEmailAsync(request.Email);
        if( userExists == null)
        {
            throw new NotFoundException(ResourceErrorMessage.USER_LOGIN_NOT_FOUND);
        }

        using var hmac = new HMACSHA512(userExists.PasswordSalt);
        var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(request.Password));
        for (int x = 0; x < computedHash.Length; x++)
        {
            if (computedHash[x] != userExists.PasswordHash[x])
            {
                throw new NotFoundException(ResourceErrorMessage.USER_LOGIN_NOT_FOUND);
            }
        }

        var token = _authRepository.GenerateToken(userExists.UserId, userExists.Email, userExists.AccountType);

        return new TokenResponse
        {
            TokenInfo = token.TokenInfo,
            Expires = token.Expires,
        };
    }

    #region Private Methods
    private void Validate(AuthLoginRequest request)
    {
        var validator = new AuthValidator();
        var result = validator.Validate(request);
        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errorMessages);
        }
    }

    #endregion Private Methods
}
