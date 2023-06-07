using System;
using System.Data.SqlClient;
using WebAPI.Models;

namespace WebAPI.Services
{
	public class InventoryService
	{
		public string _connectionString;

		public InventoryService(IConfiguration configuration)
		{
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }

		public GetInvoicesResponse GenInvoicesResponse(string company)
		{
            List<Invoice> invoices = new List<Invoice>();

            // provided the specific connection string
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                // connection needed to be opened
                sqlConnection.Open();
                using (SqlCommand command = sqlConnection.CreateCommand())
                {
                    command.CommandText = $"select * from invoice as inv join customer as c on inv.CustomerId = c.CustomerId where c.Company = '" + company + "'";

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Customer customer = new Customer
                        {
                            CustomerId = reader.GetGuid(5),
                            FirstName = reader.GetString(6),
                            LastName = reader.GetString(7),
                            Company = reader.GetString(8),
                            Created = reader.GetDateTime(9)
                        };
                        List<InvoiceItem> items = new List<InvoiceItem>();

                        Invoice invoice = new Invoice(invoiceId: reader.GetGuid(0), customer: customer, reference: reader.GetString(2), total: reader.GetDecimal(3));
                        invoice.Items.AddRange(items);
                        invoices.Add(invoice);
                    }
                }
            }

            foreach (Invoice invoice in invoices)
            {
                // provided the specific connection string
                using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                    {
                        sqlCommand.CommandText = $"select ii.*, i.*, inv.* from InvoiceItem as ii join invoice as inv on ii.InvoiceId = inv.InvoiceId join Item as i on ii.ItemId = i.ItemId where inv.InvoiceId = '{invoice.InvoiceId}'";
                        SqlDataReader reader = sqlCommand.ExecuteReader();
                        while (reader.Read())
                        {
                            Item item = new Item(
                                itemId: reader.GetGuid(5),
                                name: reader.GetString(6),
                                price: reader.GetDecimal(7),
                                created: reader.GetDateTime(8)
                                );

                            InvoiceItem invoiceItem = new InvoiceItem
                            {
                                Item = item,
                                InvoiceId = invoice.InvoiceId,
                                InvoiceItemId = reader.GetGuid(0)
                            };

                            invoice.Items.Add(invoiceItem);
                        }
                    }
                }
            }

            decimal customerInvoiceTotal = 0;

            foreach (Invoice invoice in invoices)
            {
                foreach (var invoiceItem in invoice.Items)
                {
                    // fixed accumulation 
                    customerInvoiceTotal += invoiceItem.Item.Price;
                }
            }

            return new GetInvoicesResponse()
            {
                Invoices = invoices,
                InvoicesTotal = customerInvoiceTotal
            };
        }
    }
}

