using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly ILogger<InvoicesController> _logger;
        private readonly InventoryService _inventoryService;

        public InvoicesController(ILogger<InvoicesController> logger, InventoryService inventoryService)
        {
            _logger = logger;
            _inventoryService = inventoryService;
        }

        [HttpGet]
        [Route("get/invoices/{company}")]
        public Response<GetInvoicesResponse> GetInvoices(string company)
        {
            var getInvoicesResponse = _inventoryService.GenInvoicesResponse(company);
            return new Response<GetInvoicesResponse>(responseCode: "200", getInvoicesResponse);
        }
    }
}
