using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using DataAccess;

namespace BusinessLayer
{
    public class ProductBL
    {
        //get all products
        public IEnumerable<Product> getAllProducts()
        {
            return new ProductRepositry().getAllProducts();
        }

        public IEnumerable<Product> getAllProductOfUser(string username)
        {
            return new ProductRepositry().getAllProductOfUser(username);
        }


        //create
        public void addProduct(string name, string details, int quantity, decimal price, string username)
        {
            ProductRepositry pr = new ProductRepositry();

            Product p = new Product
            {
                Name = name,
                Details = details,
                Quantity = quantity,
                Price = price,
                UsernameFK = username
            };

            pr.addProduct(p);
        }

        //get product by id
        public Product getProduct(int id)
        {
            return new ProductRepositry().getProduct(id);
        }

        //edit
        public void editProduct(int id, string name, string details, int quantity, decimal price, string username)
        {
            ProductRepositry pr = new ProductRepositry();

            Product p = new Product
            {
                ProductID = id,
                Name = name,
                Details = details,
                Quantity = quantity,
                Price = price,
                UsernameFK = username
            };

            pr.editProduct(p);
        }

        //delete
        public void deleteProduct(int id)
        {
            new ProductRepositry().deleteProduct(id);
        }

    }
}
