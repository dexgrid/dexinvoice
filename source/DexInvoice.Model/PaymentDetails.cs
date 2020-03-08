using System;
using System.Collections.Generic;
using System.Text;

namespace DexInvoice.Model
{
    public class PaymentDetails
    {
        public PaymentDetails(string recipient, string bankAccountNumber)
        {
            Recipient = recipient;
            BankAccountNumber = bankAccountNumber;
        }

        public string Recipient { get; }

        public string BankAccountNumber { get; }
    }
}
