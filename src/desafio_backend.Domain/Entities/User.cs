﻿using desafio_backend.Domain.Enums;

namespace desafio_backend.Domain;

public class User
{
    public long UserId { get; private set; } 
    public string Name { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string CpnjCpf { get; set; } = string.Empty;
    public AccountType AccountType { get; set; }
    public decimal Amount { get; set; } = 1000;
    public byte[] PasswordSalt { get; set; }
    public byte[] PasswordHash { get; set; }
    public DateTime CreatedAt { get; private set; } = DateTime.Now;
    public ICollection<Transfer> PayeeTransfers { get; set; }
    public ICollection<Transfer> PayerTransfers { get; set; }

    public User() { }
    
    public void ChangePasswordUser(byte[] pwd, byte[] pwdHash)
    {
        PasswordSalt = pwd;
        PasswordHash = pwdHash;
    }

    public void ReplaceCpfCnpj(string c)
    {
        var stringReplace = c.Replace(".", "").Replace("-", "").Replace("/", "");
        CpnjCpf = stringReplace;
    }

    public void UpdateValueAmount (decimal value)
    {
        Amount += (value);
    }
}
