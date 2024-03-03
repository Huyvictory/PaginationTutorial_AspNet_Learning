using Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaginationTutorial_AspNet_Learning.Filter;
using PaginationTutorial_AspNet_Learning.Helpers;
using PaginationTutorial_AspNet_Learning.Models;
using PaginationTutorial_AspNet_Learning.Services;
using PaginationTutorial_AspNet_Learning.Wrappers;

namespace PaginationTutorial_AspNet_Learning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IUriService _uriService;
        public CustomerController(ApplicationDbContext context, IUriService uriService)
        {
            this.context = context;
            _uriService = uriService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PaginationFilter filter)
        {
            var routeApi = Request.Path.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var listCustomers = await context.Customers
                .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                .Take(validFilter.PageSize)
                .ToListAsync();
            var totalCustomersDb = await context.Customers.CountAsync();
            var actualPagedResponse = PaginationHelper
                .CreatePagedResponse(listCustomers, validFilter, totalCustomersDb, _uriService, routeApi);
            return Ok(actualPagedResponse);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await context.Customers.Where(a => a.Id == id).FirstOrDefaultAsync();
            return Ok(new ResponseAPI<Customer>(customer));
        }
    }
}
