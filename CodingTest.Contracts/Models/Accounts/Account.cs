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

        public string PhoneFormatted
        {
            get
            {
                // Taken from https://stackoverflow.com/questions/188510/how-to-format-a-string-as-a-telephone-number-in-c-sharp
                if (string.IsNullOrEmpty(PhoneNumber)) return string.Empty;
                PhoneNumber = new System.Text.RegularExpressions.Regex(@"\D")
                    .Replace(PhoneNumber, string.Empty);
                PhoneNumber = PhoneNumber.TrimStart('1');
                if (PhoneNumber.Length == 7)
                    return Convert.ToInt64(PhoneNumber).ToString("###-####");
                if (PhoneNumber.Length == 10)
                    return Convert.ToInt64(PhoneNumber).ToString("###-###-####");
                if (PhoneNumber.Length > 10)
                    return Convert.ToInt64(PhoneNumber)
                        .ToString("###-###-#### " + new String('#', (PhoneNumber.Length - 10)));
                return PhoneNumber;
            }
        }
    }
}
