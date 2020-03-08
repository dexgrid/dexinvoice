using DexInvoice.Abstractions;
using DexInvoice.Model;
using System.Threading.Tasks;

namespace DexInvoice.Application
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IHtmlToPdfClient _htmlToPdfClient;
        private readonly ITemplateProvider _templateProvider;

        public InvoiceService(IHtmlToPdfClient htmlToPdfClient, ITemplateProvider templateProvider)
        {
            _htmlToPdfClient = htmlToPdfClient;
            _templateProvider = templateProvider;
        }

        public async Task<byte[]> CreateInvoicePdf(string templateKey, Invoice invoice)
        {
            string html = await _templateProvider.RenderTemplate(templateKey, invoice);
            return await _htmlToPdfClient.GetPdfFromHtml(html);
        }
    }
}