using System;
using Microsoft.AspNetCore.Mvc;
using MongoExample.Services;
using MongoExample.Models;

namespace MongoExample.Controllers {
    [Controller]
    [Route("api/[controller]")]
    public class SalesListController : Controller {
        private readonly MongoDBService _mongoDBService;
        public SalesListController(MongoDBService mongoDBService) {
            _mongoDBService = mongoDBService;
        }
        [HttpGet]
        public async Task<List<Sales>> Get() {
            return await _mongoDBService.GetAsync();
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Sales sales) {
            await _mongoDBService.CreateAsync(sales);
            return CreatedAtAction(nameof(Get), new { id = sales.Id }, sales);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AddToSales(int id, [FromBody] int saleId) {
            await _mongoDBService.AddToSalesListAsync(id, saleId);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            await _mongoDBService.DeleteAsync(id);
            return NoContent();
        }

        //public IActionResult Index() {
        //    return View();
        //}
    }
}
