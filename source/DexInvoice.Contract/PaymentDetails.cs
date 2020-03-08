using System;
using System.Collections.Generic;
using System.Text;

namespace DexInvoice.Contract
{
    public class PaymentDetails
    {
        public string Recipient { get; set; } = string.Empty;

        public string BankAccountNumber { get; set; } = string.Empty;
    }
}
