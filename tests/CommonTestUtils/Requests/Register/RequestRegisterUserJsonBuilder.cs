using Bogus;
using Bogus.Extensions.Brazil;
using desafio_backend.Communication.Enums;
using desafio_backend.Communication.Requests.User;

namespace CommonTestUtils.Requests.Register;
public class RequestRegisterUserJsonBuilder
{
    public static UserRegisterRequestJson Build()
    {
        return new Faker<UserRegisterRequestJson>()
            .RuleFor(u => u.Name, faker => faker.Person.FirstName)
            .RuleFor(u => u.Email, (faker, user) => faker.Internet.Email(user.Name))
            .RuleFor(u => u.AccountType, faker => faker.PickRandom<AccountType>())
            .RuleFor(u => u.Password, faker => faker.Internet.Password(prefix: "!Aa1"))
            .RuleFor(u => u.ConfirmPassword, (faker, user) => user.Password)
            .RuleFor(u => u.CpnjCpf, (faker, user) =>
            {
                return user.AccountType == AccountType.CommonUser
                    ? faker.Person.Cpf(true)
                    : faker.Company.Cnpj(true);
            });
            
    }
}
