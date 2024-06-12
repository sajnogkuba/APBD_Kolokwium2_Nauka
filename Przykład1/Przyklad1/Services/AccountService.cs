using Microsoft.EntityFrameworkCore;
using Przyklad1.Context;
using Przyklad1.Exceptions;
using Przyklad1.Models;
using Przyklad1.ResponseModels;

namespace Przyklad1.Services;

public interface IAccountService
{
    public Task<GetAccountResponse> GetAccountByIdAsync(int id);
}

public class AccountService(DataBaseContext context) : IAccountService
{
    public async Task<GetAccountResponse> GetAccountByIdAsync(int id)
    {
        var result = await context.Accounts
            .Where(acconut => acconut.AccountID == id)
            .Select(account => new GetAccountResponse()
            {
                firstName = account.AccountFirstName,
                lastName = account.AccountLastName,
                email = account.AccountEmail,
                phone = account.AccountPhone,
                role = account.Role.RoleName,
                cart = account.ShoppingCarts.Select(cart => new GetAccountResponse.GetAccountCart()
                {
                    productId = cart.ProductID,
                    productName = cart.Product.ProductName,
                    amount = cart.ShoppingCartAmount
                }).ToList()
                }).FirstOrDefaultAsync();

        return result;
    }
}