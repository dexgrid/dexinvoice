using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DexInvoice.Abstractions;
using DexInvoice.Api.Extensions;
using DexInvoice.Contract;
using DexInvoice.Contract.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DexInvoice.Api.Controllers
{
    [ApiController]
    [Route("invoice")]
    public class InvoiceController : ControllerBase
    {
        private readonly ILogger<InvoiceController> _logger;
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(ILogger<InvoiceController> logger, IInvoiceService invoiceService)
        {
            _logger = logger;
            _invoiceService = invoiceService;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("templates")]
        public IActionResult Get()
        {
            return Ok(new { });
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/octet-stream", Type = typeof(FileResult))]
        [HttpPost("{templateKey}")]
        public async Task<IActionResult> PostAsync(string templateKey, Invoice invoice)
        {
            var model = invoice.MapToModel();
            var file = await _invoiceService.CreateInvoicePdf(templateKey, model);
            return File(file, "application/octet-stream", "invoice.pdf");
        }
    }
}
