using DexInvoice.Model;
using System;
using System.Collections.Generic;
using Xunit;

namespace DexInvoice.ModelTests
{
    public class InvoiceTests
    {
        [Fact]
        public void ItCanCalculteInvoiceTotalWithoutTaxes()
        {
            var item1 = new InvoiceItem(1, "test description", 4, 5, 20);
            var item2 = new InvoiceItem(1, "test description", 1, 7.5M, 20);
            Invoice invoice = CreateInvoice(new List<InvoiceItem> { item1, item2 });
            Assert.Equal(27.5M, invoice.TotalWithoutTaxes);
        }

        [Fact]
        public void ItCanCalculteInvoiceTotalWithTaxes()
        {
            var item1 = new InvoiceItem(1, "test description", 4, 5, 20);
            var item2 = new InvoiceItem(1, "test description", 1, 5, 20);
            Invoice invoice = CreateInvoice(new List<InvoiceItem> { item1, item2 });
            Assert.Equal(30, invoice.TotalWithTaxes);
        }


        [Fact]
        public void ItCanCalculteTaxRates()
        {
            var item1 = new InvoiceItem(1, "test description", 1, 10, 20);
            var item2 = new InvoiceItem(1, "test description", 1, 5, 10);
            Invoice invoice = CreateInvoice(new List<InvoiceItem> { item1, item2 });
            Assert.Equal(17.5M, invoice.TotalWithTaxes);
            Assert.Equal((20M, 12M), invoice.TaxPrices[0]);
            Assert.Equal((10M, 5.5M), invoice.TaxPrices[^1]);
        }

        private static Invoice CreateInvoice(List<InvoiceItem> invoiceItems)
        {
            var sender = new Sender("DEXGRID OU", "EE0948320984", "43284932", "test@example.com", "example.com", new Address("Street 1", string.Empty, "1800AA", "Amsterdam", "The Netherlands"));
            var recipient = new Recipient("John Smith", "j.smith@example.com", new Address("Squate 1", string.Empty, "28473", "New York", "USA"));
            var paymentDetails = new PaymentDetails("CompanyName", "1234678");

            var invoice = new Invoice("2019.01.01.132",
                                      new DateTime(2019, 1, 1),
                                      null,
                                      sender,
                                      recipient,
                                      string.Empty,
                                      string.Empty,
                                      "en-US",
                                      invoiceItems,
                                      paymentDetails);
            return invoice;
        }
    }
}
