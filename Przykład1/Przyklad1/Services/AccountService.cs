using Microsoft.EntityFrameworkCore;
using Przyklad1.Context;
using Przyklad1.Exceptions;
using Przyklad1.Models;

namespace Przyklad1.Services;

public interface IAccountService
{
    public Task<Account> GetAccountByIdAsync(int id);
}

public class AccountService(DataBaseContext context) : IAccountService
{
    public async Task<Account> GetAccountByIdAsync(int id)
    {
        var result = await context.Accounts
            .Where(e => e.AccountID == id)
            .FirstOrDefaultAsync();

        if (result is null)
        {
            throw new NotFoundException($"Account with id:{id} does not exist");
        }

        return result;
    }
}