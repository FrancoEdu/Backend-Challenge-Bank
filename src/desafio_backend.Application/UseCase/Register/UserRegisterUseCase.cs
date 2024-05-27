using AutoMapper;
using desafio_backend.Communication.Requests.User;
using desafio_backend.Communication.Response.User;
using desafio_backend.Domain;
using desafio_backend.Domain.Repositories.Users;
using desafio_backend.Exception.ExceptionBase;
using PdfSharp.Drawing;

namespace desafio_backend.Application.UseCase.Register;
public class UserRegisterUseCase : IUserRegisterUseCase
{
    private readonly IUserWriteOnlyRepository _userWriteOnlyRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UserRegisterUseCase(IMapper mapper, IUnitOfWork unitOfWork, IUserWriteOnlyRepository userWriteOnlyRepository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _userWriteOnlyRepository = userWriteOnlyRepository;
    }

    public async Task<UserRegisterResponseJson> Execute(UserRegisterRequestJson request)
    {
        Validate(request);

        var user = _mapper.Map<User>(request);
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
    }
    #endregion Private Methods
}
