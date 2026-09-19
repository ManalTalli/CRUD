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
            return View();
        }

        public ViewResult Store(Product request)
        {
            context.Products.Add(request);

            context.SaveChanges();

            return View("Create");
        }
        public ViewResult Details(int id)
        {
            var User = context.Products.Find(id);
            return View(User);
        }
        public ViewResult Edit(int id)
        {
            var Product = context.Products.Find(id);
            return View(Product);
        }
        public ViewResult Update(Product request)
        {
            context.Products.Update(request);
            context.SaveChanges();
            return View("Create");
        }
        public ViewResult Delete(int id)
        {

            var Product = context.Products.Find(id);
            context.Products.Remove(Product);
            context.SaveChanges();
            return View("Create");
        }

    }
}
