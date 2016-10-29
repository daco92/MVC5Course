using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC5Course.Models
{   
	public  class ProductRepository : EFRepository<Product>, IProductRepository
	{

        public override IQueryable<Product> All()
        {
            return base.All().Where(c => c.IsDeleted == false);
        }

        public override void Delete(Product product)
        {
            product.IsDeleted = true;
        }

        public Product Find(int id)
        {
            return this.All().FirstOrDefault(p => p.ProductId == id);
        }

        internal IQueryable<Product> Get取前n筆資料(int TaksSize)
        {

            return this.All().Take(TaksSize);


        }
    }

	public  interface IProductRepository : IRepository<Product>
	{

	}
}