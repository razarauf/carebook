using WebAPI.Controllers;

namespace WebAPI.Models
{
    public class Invoice
    {
        public Guid InvoiceId { get; set; }
        public Customer Customer { get; set; }
        public string Reference { get; set; }
        public List<InvoiceItem> Items { get; set; }
        public decimal Total { get; set; }

        /// <summary>
        /// Generates a new invoice instance
        /// </summary>
        /// <param name="invoiceId"></param>
        /// <param name="customer"></param>
        /// <param name="description"></param>
        public Invoice(Guid invoiceId, Customer customer, string reference, decimal total)
        {
            InvoiceId = invoiceId;
            Customer = customer;
            Reference = reference;
            Items = new List<InvoiceItem>();
            Total = total;
        }

        public void AddItemToInvoice(InvoiceItem item)
        {
            this.Items.Add(item);
        }
    }
}
