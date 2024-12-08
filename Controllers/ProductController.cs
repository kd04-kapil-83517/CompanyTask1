using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication123.Data;
using WebApplication123.Models;

namespace WebApplication123.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var products = _context.Products.Include(p => p.Category)
                .OrderBy(p => p.ProductId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(p => new
                {
                    p.ProductId,
                    p.ProductName,
                    p.CategoryId,
                    p.Category.CategoryName
                }).ToList();

            return View(products);
        }

        public ActionResult Create()
        {
            ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            return View(product);
        }

        public ActionResult Edit(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) return HttpNotFound();
            ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(product).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            return View(product);
        }

        public ActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) return HttpNotFound();
            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}
