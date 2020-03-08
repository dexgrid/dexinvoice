using DexInvoice.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DexInvoice.Abstractions
{
    public interface IInvoiceService
    {
        public Task<byte[]> CreateInvoicePdf(string template, Invoice invoice);
    }
}
