using DexInvoice.Model;
using System.Threading.Tasks;

namespace DexInvoice.Abstractions
{
    public interface ITemplateProvider
    {
        Task<string> RenderTemplate(string templateKey, Invoice invoice);
    }
}
