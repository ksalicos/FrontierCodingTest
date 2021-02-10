using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingTest.Common.Models.Accounts;

namespace CodingTest.Common.Models.ViewModels
{
    public class GetAllViewModel
    {
        public IEnumerable<Account> Active { get; set; }
        public IEnumerable<Account> Overdue { get; set; }
        public IEnumerable<Account> Inactive { get; set; }
    }
}
