using System;
using System.Collections.Generic;
using System.Text;

namespace DexInvoice.Model
{
    public class InvoiceItem
    {
        public InvoiceItem(int number, string description, decimal quantity, decimal unitPrice, decimal taxPercentage)
        {
            Number = number;
            Description = description;
            Quantity = quantity;
            UnitPrice = unitPrice;
            TaxPercentage = taxPercentage;
        }
        public int Number { get; }

        public string Description { get; }

        public decimal Quantity { get; }

        public decimal UnitPrice { get; }

        public decimal TaxPercentage { get; }

        public decimal TotalExcludingTax => Quantity * UnitPrice;

        public decimal TotalIncludingTax => TotalExcludingTax + TotalTaxAmount;

        private decimal TotalTaxAmount => TotalExcludingTax / 100 * TaxPercentage;
    }
}
