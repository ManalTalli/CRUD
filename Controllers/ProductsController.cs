using CRUD.Data;
using CRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    public class ProductsController : Controller
    {
        ApplicationDBContext context = new ApplicationDBContext();
        public ViewResult Index()
        {
            var products = context.Products.ToList();
            return View(products);
        }
        public ViewResult Create()
        {
            return View(new Product());
        }

        public IActionResult Store(Product request)
        {
            if (ModelState.IsValid) { 
            context.Products.Add(request);

            context.SaveChanges();
                var products = context.Products.ToList();

                return RedirectToAction("Index");
            }
            else
            {
                return View("Create", request);
            }
        }
        public IActionResult Details(int id)
        {
            var User = context.Products.Find(id);
            return View(User);
        }
        public IActionResult Edit(int id)
        {
            var Product = context.Products.Find(id);
            return View(Product);
        }
        public IActionResult Update(Product request)
        {
            context.Products.Update(request);
            context.SaveChanges();
            return View("Create");
        }
        public IActionResult Delete(int id)
        {

            var Product = context.Products.Find(id);
            context.Products.Remove(Product);
            context.SaveChanges();
            return View("Create");
        }

    }
}
