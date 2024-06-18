using CommonTestUtils.Requests.Register;
using desafio_backend.Application.UseCase.Register;
using desafio_backend.Communication.Extensions;
using desafio_backend.Exception;
using FluentAssertions;

namespace Validators.Test.Register;
public class RegisterUserValidatorTest
{
    [Fact]
    public void Success()
    {
        var validator = new UserRegisterValidator();
        var req = RequestRegisterUserJsonBuilder.Build();

        var result = validator.Validate(req);

        result.IsValid.Should().BeTrue();
    }

    [Theory]
    [InlineData("")]
    [InlineData("      ")]
    [InlineData(null)]
    public void Error_Name_Empty(string name)
    {
        var validator = new UserRegisterValidator();
        var req = RequestRegisterUserJsonBuilder.Build();
        req.Name = name;

        var result = validator.Validate(req);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessage.NAME_REQUIRED));
    }

    [Theory]
    [InlineData("")]
    [InlineData("      ")]
    [InlineData(null)]
    public void Error_Email_Empty(string email) 
    {
        var validator = new UserRegisterValidator();
        var req = RequestRegisterUserJsonBuilder.Build();
        req.Email = email;

        var result = validator.Validate(req);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessage.EMAIL_REQUIRED));
    }

    [Theory]
    [InlineData("email.com")]
    [InlineData("email@")]
    public void Error_Email_Invalid(string email)
    {
        var validator = new UserRegisterValidator();
        var req = RequestRegisterUserJsonBuilder.Build();
        req.Email = email;

        var result = validator.Validate(req);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessage.EMAIL_INVALID));
    }

    [Theory]
    [InlineData("")]
    [InlineData("      ")]
    [InlineData(null)]
    public void Error_CpfCnpj_Empty(string cpf) 
    {
        var validator = new UserRegisterValidator();
        var req = RequestRegisterUserJsonBuilder.Build();
        req.CpnjCpf = cpf;

        var result = validator.Validate(req);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessage.CPF_REQUIRED));
    }

    [Theory]
    [InlineData("433.625.808-21")]
    [InlineData("43362580821")]
    public void Error_Cpf_Invalid(string cpf)
    {
        var req = RequestRegisterUserJsonBuilder.Build();
        req.AccountType = desafio_backend.Communication.Enums.AccountType.CommonUser;
        req.CpnjCpf = cpf;

        var validateCpf = ValidateCpfCnpj.ValidadeCPF(req.CpnjCpf);

        validateCpf.Should().BeFalse();
    }

    [Theory]
    [InlineData("67.774.846/0001-34")]
    [InlineData("80492047000112")]
    public void Error_Cnpj_Invalid(string cnpj)
    {
        var req = RequestRegisterUserJsonBuilder.Build();
        req.AccountType = desafio_backend.Communication.Enums.AccountType.Shopkeeper;
        req.CpnjCpf = cnpj;

        var result = ValidateCpfCnpj.ValidateCnpj(req.CpnjCpf);

        result.Should().BeFalse();
    }

    [Theory]
    [InlineData("!We23asada")]
    [InlineData("!@sdw@@22xsXX")]
    public void Error_Pwd_And_Confirm_Pwd_Not_Equals(string pwd)
    {
        var validator = new UserRegisterValidator();
        var req = RequestRegisterUserJsonBuilder.Build();
        req.ConfirmPassword = pwd;

        var result = validator.Validate(req);
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessage.PASSWORD_NOT_EQUALS));
    }
}
