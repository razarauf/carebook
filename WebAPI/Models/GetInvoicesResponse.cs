namespace WebAPI.Models
{
    public class GetInvoicesResponse
    {
        public List<Invoice> Invoices { get; set;}
        public decimal InvoicesTotal { get; set; }
    }
}
