using DexInvoice.Contract;
using System.Linq;

namespace DexInvoice.Api.Extensions
{
    public static class InvoiceExtensions
    {
        public static Model.Invoice MapToModel(this Invoice source) => 
            new Model.Invoice(
                source.Number,
                source.Date,
                source.DueDate,
                source.Sender.MapToModel(),
                source.Recipient.MapToModel(),
                source.Message,
                source.PaymentRemarks,
                source.DisplayCulture,
                source.Items.Select(x => x.MapToModel()).ToList(),
                source.PaymentDetails.MapToModel());

        public static Model.Sender MapToModel(this Sender source) => 
            new Model.Sender(
                source.Name,
                source.VatNumber,
                source.RegistrationNumber,
                source.Email,
                source.Website,
                source.Address.MapToModel());

        public static Model.Address MapToModel(this Address source) => 
            new Model.Address(
                source.AddressLine1,
                source.AddressLine2,
                source.PostalCode,
                source.City,
                source.Country);

        public static Model.Recipient MapToModel(this Recipient source) =>
            new Model.Recipient(
                source.Name,
                source.Email,
                source.Address.MapToModel());

        public static Model.InvoiceItem MapToModel(this InvoiceItem source) =>
            new Model.InvoiceItem(
                source.Number,
                source.Description,
                source.Quantity,
                source.UnitPrice,
                source.TaxPercentage);

        public static Model.PaymentDetails MapToModel(this PaymentDetails source) =>
            new Model.PaymentDetails(
                source.Recipient,
                source.BankAccountNumber);
    }
}
