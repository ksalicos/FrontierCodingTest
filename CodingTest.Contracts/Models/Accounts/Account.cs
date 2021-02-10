using System;
using System.Text.Json.Serialization;
using CodingTest.Common.Enums;

namespace CodingTest.Common.Models.Accounts
{
    public class Account
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public decimal AmountDue { get; set; }

        public DateTimeOffset? PaymentDueDate { get; set; }

        [JsonPropertyName("AccountStatusId")]
        public AccountStatus Status { get; set; }
    }
}
