using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace DataAccess
{
    public class ProductRepositry : ConnectionClass
    {
        public ProductRepositry() : base() { }

        //get all products
        public IEnumerable<Product> getAllProducts()
        {
            return entities.Products.AsEnumerable();
        }

        //get all products of user
        public IEnumerable<Product> getAllProductOfUser(string username)
        {
            return (from p in entities.Products
                    join u in entities.Users
                        on p.UsernameFK equals u.Username
                    where p.UsernameFK == username
                    select p);
        }
        //create
        public void addProduct(Product p)
        {
            entities.AddToProducts(p);
            entities.SaveChanges();
        }

        //get product by id
        public Product getProduct(int id)
        {
            return entities.Products.SingleOrDefault(x => x.ProductID == id);
        }

        //edit
        public void editProduct(Product p)
        {
            entities.Products.Attach(getProduct(p.ProductID));
            entities.Products.ApplyCurrentValues(p);
            entities.SaveChanges();
        }

        //delete
        public void deleteProduct(int id)
        {
            entities.Products.DeleteObject(getProduct(id));
            entities.SaveChanges();
        }
    }
}
