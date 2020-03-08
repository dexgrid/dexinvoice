using System;
using System.Collections.Generic;
using System.Text;

namespace DexInvoice.Contract.Response
{
    public class InvoiceCreated
    {
        public string PdfUrl { get; set; } = string.Empty;
    }
}
