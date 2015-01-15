using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Traders_Marketplace.Models;
using BusinessLayer;
using Common;

namespace Traders_Marketplace.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/

        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult CreateProduct()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult CreateProduct(CreateProductModel cp)
        {
            new ProductBL().addProduct(cp.Name, cp.Details, cp.Quantity, cp.Price, User.Identity.Name);

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        [HttpGet]
        public ActionResult ProductManagement()
        {
            return View(new ProductBL().getAllProductOfUser(User.Identity.Name));
        }


        [HttpGet]
        public ActionResult DisplayProduct()
        {
            return View(new ProductBL().getAllProducts());
        }

        [Authorize]
        [HttpGet]
        public ActionResult EditProduct(int productID)
        {
            Session["productToUpdate"] = productID;

            Product p = new ProductBL().getProduct(productID);

            EditProductModel epm = new EditProductModel();
            epm.ProductID = p.ProductID;
            epm.Name = p.Name;
            epm.Details = p.Details;
            epm.Quantity = p.Quantity;
            epm.Price = p.Price;
            epm.Username = p.UsernameFK;

            return View(epm);
        }

        [Authorize]
        [HttpPost]
        public ActionResult EditProduct(EditProductModel epm)
        {

            if (ModelState.IsValid)
            {
                new ProductBL().editProduct(epm.ProductID, epm.Name, epm.Details, epm.Quantity, epm.Price, epm.Username);

                return RedirectToAction("Index", "Home");
            }
            return View(epm);
        }

        [Authorize]
        public ActionResult deleteProduct(int id)
        {
            new ProductBL().deleteProduct(id);
            return RedirectToAction("ProductManagement");
        }

    }
}
