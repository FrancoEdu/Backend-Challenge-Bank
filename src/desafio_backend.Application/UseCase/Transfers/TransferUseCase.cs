using desafio_backend.Application.Integration.UseCase;
using desafio_backend.Communication.Requests.Transfers;
using desafio_backend.Communication.Response.Transfer;
using desafio_backend.Domain;
using desafio_backend.Domain.Repositories.Transfers;
using desafio_backend.Domain.Repositories.Users;
using desafio_backend.Domain.ResourcesMessages;
using desafio_backend.Exception;
using desafio_backend.Exception.ExceptionBase;

namespace desafio_backend.Application.UseCase.Transfers;
public class TransferUseCase : ITransferUseCase
{
    private readonly ITransferWriteOnlyRepository _transferWriteOnlyRepository;
    private readonly IUserWriteOnlyRepository _userWriteOnlyRepository;
    private readonly IUserReadOnlyRepository _userReadOnlyRepository;
    private readonly IAuthorizeIntegration _authorizeIntegration;
    private readonly INotifyIntegration _notifierIntegration;
    private readonly IUnitOfWork _unitOfWork;

    public TransferUseCase(IUserReadOnlyRepository userReadOnlyRepository,
        IUserWriteOnlyRepository userWriteOnlyRepository,
        IUnitOfWork unitOfWork,
        ITransferWriteOnlyRepository transferWriteOnlyRepository,
        IAuthorizeIntegration authorizeIntegration,
        INotifyIntegration notifierIntegration)
    {
        _userReadOnlyRepository = userReadOnlyRepository;
        _userWriteOnlyRepository = userWriteOnlyRepository;
        _unitOfWork = unitOfWork;
        _transferWriteOnlyRepository = transferWriteOnlyRepository;
        _authorizeIntegration = authorizeIntegration;
        _notifierIntegration = notifierIntegration;
    }

    public async Task<TransferResponse> Execute(TransferRequest transfer, long payerId)
    {
        Validate(transfer);

        var payer = await _userReadOnlyRepository.GetByIdAsync(payerId) ?? throw new NotFoundException(ResourceErrorMessage.PAYER_NOT_FOUND);
        var payee = await _userReadOnlyRepository.GetByIdAsync(transfer.Payee) ?? throw new NotFoundException(ResourceErrorMessage.UNKNOWN_RECIPIENT);

        if (payer.Amount <= 0) throw new InsufficientBalanceException(ResourceErrorMessage.INSUFFICIENT_BALANCE);
        payer.UpdateValueAmount(transfer.Value * -1);
        _userWriteOnlyRepository.UpdateUserAmountValue(payer);

        payee.UpdateValueAmount(transfer.Value);
        _userWriteOnlyRepository.UpdateUserAmountValue(payee);

        var newTransfer = new Transfer(payer.UserId, payee.UserId, transfer.Value);

        await _transferWriteOnlyRepository.Add(newTransfer);

        var responseAuthorize = await _authorizeIntegration.AuthorizeTransfer();
        if (!responseAuthorize) throw new UnauthorizedTransferException(ResourceErrorMessage.NOT_AUTHORIZED_TRANSFER);

        var responseNotify = await _notifierIntegration.NotifyTransfer();
        if (!responseNotify) throw new UnavailableServiceNotifyException(ResourceErrorMessage.UNAVAILABLE_SERVICE_NOTIFY);

        await _unitOfWork.Commit();

        return new TransferResponse
        {
            Message = ResourceReportGenerateMessage.SUCCESS_TRANSFER,
        };
    }

    private void Validate(TransferRequest request)
    {
        var validator = new TransferValidator();
        var result = validator.Validate(request);
        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
