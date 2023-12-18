using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQlite.Models;

namespace NewProject.Controllers
{
    [ApiController]
    [Route("api/Purchases")]
    public class PurchaseController : ControllerBase
    {
        private readonly ILogger<PurchaseController> _logger;
        private readonly ApplicationContext _context;

        public PurchaseController(ILogger<PurchaseController> logger, ApplicationContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("GetPurchasesByUserId", Name = "GetPurchasesByUserId")]
        public IEnumerable<Purchase> GetPurchasesByUserId(Guid userId)
        {
            var userPurchases = _context.Purchases.Where(p => p.UserId == userId).ToList();// вывод покупок пренадлежащих одному пользователю ро Id
            return userPurchases;
        }

        [HttpPost("CreatePurchase", Name = "CreatePurchase")]
        public async Task<IActionResult> CreatePurchase(Guid userId, Purchase newPurchase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingUser = _context.Users.FirstOrDefault(u => u.Id == userId);

            if (existingUser == null)
            {
                return BadRequest("Invalid UserId");
            }

            newPurchase.UserId = existingUser.Id; // Присваиваем новой покупке существующего пользователя

            _context.Purchases.Add(newPurchase);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPurchasesByUserId", new { userId = existingUser.Id }, newPurchase);
        }

        [HttpPut("UpdatePurchase/{id}", Name = "UpdatePurchase")]
        public IActionResult UpdatePurchase(Guid id, Purchase updatedPurchase)
        {
            var existingPurchase = _context.Purchases.FirstOrDefault(p => p.Id == id);

            if (existingPurchase == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            existingPurchase.ProductName = updatedPurchase.ProductName;
            existingPurchase.Price = updatedPurchase.Price;

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("DeletePurchase/{id}", Name = "DeletePurchase")]
        public IActionResult DeletePurchase(Guid id)
        {
            var purchaseToDelete = _context.Purchases.FirstOrDefault(p => p.Id == id);

            if (purchaseToDelete == null)
            {
                return NotFound();
            }

            _context.Purchases.Remove(purchaseToDelete);
            _context.SaveChanges();

            return NoContent();
        }
    }
}