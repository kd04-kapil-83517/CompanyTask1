using Microsoft.EntityFrameworkCore;

namespace WebApplication123.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        // Foreign Key for Category
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
    

 

}
