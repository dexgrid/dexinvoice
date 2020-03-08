using System;
using System.Collections.Generic;
using System.Text;

namespace DexInvoice.Model
{
    public class Sender
    {
        public Sender(string name, string vatNumber, string registrationNumber, string email, string website, Address address)
        {
            Name = name;
            VatNumber = vatNumber;
            RegistrationNumber = registrationNumber;
            Email = email;
            Website = website;
            Address = address;
        }

        public string Name { get; }
        public string VatNumber { get; }
        public string RegistrationNumber { get; }
        public string Email { get; set; }
        public string Website { get; set; }
        public Address Address { get;  }
    }
}
