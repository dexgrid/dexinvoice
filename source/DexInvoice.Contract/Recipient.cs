using System;
using System.Collections.Generic;
using System.Text;

namespace DexInvoice.Contract
{
    public class Recipient
    {

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public Address Address { get; set; } = new Address();
    }
}
