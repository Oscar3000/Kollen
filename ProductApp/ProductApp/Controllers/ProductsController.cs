using ProductApp.DataAccess;
using ProductApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductApp.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private Respository _repo = new Respository();
        // GET: Products
        [AllowAnonymous]
        public ActionResult Index()
        {
            var Products = _repo.getAllProducts();
            return Request.IsAjaxRequest() ? (ActionResult)PartialView("ProductList",Products) :View(Products);
        }

        [AllowAnonymous]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "Picture")]Product model, HttpPostedFileBase picture)
        {
            if (ModelState.IsValid)
            {   
                if(picture != null)
                {
                    if(picture.ContentLength > (4 * 1024 * 1024))
                    {
                        ModelState.AddModelError("", "Image must not be greater than 4MB");
                        return View(model);
                    }
                    if(!(picture.ContentType == "image/jpeg" || picture.ContentType == "image/png"))
                    {
                        ModelState.AddModelError("", "Image must be either Jpeg or PNG");
                        return View(model);
                    }

                    model.Picture = new byte[picture.ContentLength];
                    picture.InputStream.Read(model.Picture, 0, picture.ContentLength);
                }else
                {
                    ModelState.AddModelError("", "Image is Needed for the product");
                    return View(model);
                }
                _repo.CreateProduct(model);
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Error Occured try again.");
            return View(model);
        }

        public ActionResult Update(int? id)
        {
            if(id == null)
            {
               return View("Error");
            }
            var Product = _repo.getProductById(id);
            if(Product == null)
            {
                return View("Error");
            }
            return View(Product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Product model, HttpPostedFileBase picture)
        {
            if (ModelState.IsValid)
            {
                if(picture != null)
                {
                    if(picture.ContentLength > (4 * 1024 * 1024))
                    {
                        ModelState.AddModelError("", "Image must not be greater than 4MB");
                        return View(model);
                    }
                    if(!(picture.ContentType == "image/jpeg"|| picture.ContentType == "image/png"))
                    {
                        ModelState.AddModelError("", "Image must be either jpeg or PNG");
                        return View(model);
                    }

                    model.Picture = new byte[picture.ContentLength];
                    picture.InputStream.Read(model.Picture, 0, picture.ContentLength);
                }

                _repo.UpdateProduct(model);
            }
            ModelState.AddModelError("", "Error Occured try again.");
            return View(model);
        }
        [AllowAnonymous]
        public ActionResult Item(string name, int? code, string category)
        {
            if(name == null || code == null || category == null)
            {
                return View("Error");
            }
            var Product = _repo.getProduct(name, code, category);
            if(Product == null)
            {
                return View("Error");
            }
            return View(Product);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id)
        {
            if(id == null)
            {
                return View("Error");
            }
            var product = _repo.getProductById(id);
            if(product == null)
            {
                return View("Error");
            }
            _repo.DeleteProduct(product.ProductId);
            return RedirectToAction("Index");
        }

    }
}