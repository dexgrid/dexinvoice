using System;
using System.Collections.Generic;
using System.Text;

namespace DexInvoice.Model
{
    public class Recipient
    {
        public Recipient(string name, string email, Address address)
        {
            Name = name;
            Email = email;
            Address = address;
        }

        public string Name { get; }

        public string Email { get; }

        public Address Address { get; }
    }
}
