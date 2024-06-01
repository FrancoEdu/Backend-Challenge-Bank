using AutoMapper;
using desafio_backend.Communication.Enums;
using desafio_backend.Communication.Extensions;
using desafio_backend.Communication.Requests.User;
using desafio_backend.Communication.Response.User;
using desafio_backend.Domain;
using desafio_backend.Domain.Repositories.Users;
using desafio_backend.Exception;
using desafio_backend.Exception.ExceptionBase;
using System.Security.Cryptography;

namespace desafio_backend.Application.UseCase.Register;
public class UserRegisterUseCase : IUserRegisterUseCase
{
    private readonly IUserWriteOnlyRepository _userWriteOnlyRepository;
    private readonly IUserReadOnlyRepository _userReadOnlyRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UserRegisterUseCase(IMapper mapper, IUnitOfWork unitOfWork, IUserWriteOnlyRepository userWriteOnlyRepository, IUserReadOnlyRepository userReadOnlyRepository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _userWriteOnlyRepository = userWriteOnlyRepository;
        _userReadOnlyRepository = userReadOnlyRepository;
    }

    public async Task<UserRegisterResponseJson> Execute(UserRegisterRequestJson request)
    {
        Validate(request);

        var user = _mapper.Map<User>(request);

        var emailExists = await _userReadOnlyRepository.GetByEmailAsync(request.Email);
        if (emailExists is not null) throw new EmailAlreadyExistsException(ResourceErrorMessage.ALREADY_EXISTS_EMAIL);

        var cpfExists = await _userReadOnlyRepository.GetByCpfCnpjAsync(request.CpnjCpf);
        if (cpfExists is not null)
        {
            throw new CpfCnpjAlreadyExistsException(
                    request.AccountType.Equals(AccountType.CommonUser) ?
                    ResourceErrorMessage.USER_CPF_ALREADY_EXISTS :
                    ResourceErrorMessage.USER_CNPJ_ALREADY_EXISTS
                );
        }

        HashPasswordUser(user, request.Password);
        user.ReplaceCpfCnpj(request.CpnjCpf);

        await _userWriteOnlyRepository.Add(user);
        await _unitOfWork.Commit();

        return _mapper.Map<UserRegisterResponseJson>(user);
    }

    #region Private Methods

    private void Validate(UserRegisterRequestJson request)
    {
        var validator = new UserRegisterValidator();
        var result = validator.Validate(request);
        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errorMessages);
        }

        bool isValid = request.AccountType.Equals(AccountType.CommonUser) ?
            ValidateCpfCnpj.ValidadeCPF(request.CpnjCpf) : 
            ValidateCpfCnpj.ValidateCnpj(request.CpnjCpf);

        if(!isValid)
        {
            throw new ErrorOnValidationCpfCnpjException(
                    request.AccountType.Equals(AccountType.CommonUser) ?
                    ResourceErrorMessage.CPF_INVALID :
                    ResourceErrorMessage.CNPJ_INVALID
                );
        }
    }

    private void HashPasswordUser(User user, string password)
    {
        using var hmac = new HMACSHA512();
        byte[] pwd = hmac.Key;
        byte[] pwdHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        user.ChangePasswordUser(pwd, pwdHash);
    }


    #endregion Private Methods
}
