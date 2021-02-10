using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CodingTest.Common.Models.Accounts;
using CodingTest.Common.Models.ViewModels;

namespace CodingTest.Common.Services
{
    public interface IAccountService
    {
        Task<GetAllViewModel> GetAll();
    }

    public class AccountService : IAccountService
    {
        private readonly string _apiUrl;
        private static readonly HttpClient _client = new HttpClient();

        public AccountService(string apiUrl)
        {
            _apiUrl = apiUrl;
        }

        public async Task<GetAllViewModel> GetAll()
        {
            var result = _client.GetStreamAsync(_apiUrl);
            var accounts = await JsonSerializer.DeserializeAsync<List<Account>>(await result);
            return new GetAllViewModel
            {
                Active = accounts.Where(account => account.Status == Enums.AccountStatus.Active).ToArray(),
                Overdue = accounts.Where(account => account.Status == Enums.AccountStatus.Overdue).ToArray(),
                Inactive = accounts.Where(account => account.Status == Enums.AccountStatus.Inactive).ToArray()
            };
        }
    }
}
