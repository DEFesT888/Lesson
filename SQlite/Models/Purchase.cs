using SQlite.Models;
using System.Text.Json.Serialization;

namespace SQlite.Models
{
    public class Purchase
    {
        public Guid Id { get; set; }

        public string ProductName { get; set; } = null!;

        public decimal Price { get; set; }
       
        public Guid UserId { get; set; } 
    }
}
