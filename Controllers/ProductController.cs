using Microsoft.AspNetCore.Mvc;
using app.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyMvcApp.Controllers
{
    public class ProductsController : Controller
    {
        private static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Product1", Price = 10.0M },
            new Product { Id = 2, Name = "Product2", Price = 20.0M }
        };

        // GET: /Products
        public IActionResult Index()
        {
            return View(products);
        }

        // GET: /Products/Details/5
        public IActionResult Details(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // GET: /Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                product.Id = products.Max(p => p.Id) + 1;
                products.Add(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: /Products/Edit/5
        public IActionResult Edit(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: /Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var existingProduct = products.FirstOrDefault(p => p.Id == id);
                if (existingProduct == null)
                {
                    return NotFound();
                }

                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;

                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: /Products/Delete/5
        public IActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: /Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            products.Remove(product);
            return RedirectToAction(nameof(Index));
        }
    }
}
