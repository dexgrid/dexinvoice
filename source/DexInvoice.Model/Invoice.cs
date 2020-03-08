using System;
using System.Collections.Generic;
using System.Linq;

namespace DexInvoice.Model
{
    public class Invoice
    {
        public Invoice(string number,
                       DateTime date,
                       DateTime? dueDate,
                       Sender sender,
                       Recipient recipient,
                       string message,
                       string paymentRemarks,
                       string displayCulture,
                       IReadOnlyList<InvoiceItem> items,
                       PaymentDetails paymentDetails)
        {
            Number = number;
            Date = date;
            DueDate = dueDate;
            Sender = sender;
            Recipient = recipient;
            Message = message;
            PaymentRemarks = paymentRemarks;
            DisplayCulture = displayCulture;
            Items = items;
            PaymentDetails = paymentDetails;
        }

        /// <summary>
        /// The invoice number
        /// </summary>
        public string Number { get; }

        /// <summary>
        /// The invoice date.
        /// </summary>
        public DateTime Date { get; }

        /// <summary>
        /// The date the invoice is due to be paid.
        /// </summary>
        public DateTime? DueDate { get; }

        /// <summary>
        /// Sender of the invoice.
        /// </summary>
        public Sender Sender { get; }

        /// <summary>
        /// Recipient of the invoice.
        /// </summary>
        public Recipient Recipient { get; }

        /// <summary>
        /// A custom message to be displayed on the invoice.
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Remarks next to the payment details.
        /// </summary>
        public string PaymentRemarks { get; }

        /// <summary>
        /// The format to display currencies and dates. For example: en-US, nl-NL.
        /// </summary>
        public string DisplayCulture { get; }

        /// <summary>
        /// A list of invoice items.
        /// </summary>
        public IReadOnlyList<InvoiceItem> Items { get; }

        public PaymentDetails PaymentDetails { get; }

        public decimal TotalWithoutTaxes => Items.Sum(m  => m.TotalExcludingTax);

        public decimal TotalWithTaxes => Items.Sum(m => m.TotalIncludingTax);

        public IReadOnlyList<(decimal, decimal)> TaxPrices => Items.GroupBy(x => x.TaxPercentage).Select(x => (x.Key, x.Sum(y => y.TotalIncludingTax))).ToList();
    }
}
