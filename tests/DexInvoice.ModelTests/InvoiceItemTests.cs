using DexInvoice.Model;
using System;
using Xunit;

namespace DexInvoice.ModelTests
{
    public class InvoiceItemTests
    {
        [Fact]
        public void ItCanCalculteLineTotalWithoutTaxes()
        {
            var item = new InvoiceItem(1, "test description", 4, 5, 20);
            Assert.Equal(20, item.TotalExcludingTax);
        }

        [Fact]
        public void ItCanCalculateLineTotalWithTaxes()
        {
            var item = new InvoiceItem(1, "test description", 1, 10, 20);
            Assert.Equal(12, item.TotalIncludingTax);
        }
    }
}
