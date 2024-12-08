using Microsoft.EntityFrameworkCore;
 
namespace WebApplication123.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        // Navigation property for related products
        public virtual ICollection<Product> Products { get; set; }
    }
    



}
