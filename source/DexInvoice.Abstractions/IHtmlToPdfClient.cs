using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DexInvoice.Abstractions
{
    public interface IHtmlToPdfClient
    {
        Task<byte[]> GetPdfFromHtml(string html);
    }
}
