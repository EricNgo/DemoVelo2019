using System.Collections.Generic;
using TeduShop.Data.Infrastructure;
using TeduShop.Model.Models;
using System.Linq;

namespace TeduShop.Data.Repositories
{ 
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetListProductByTag(string tagId, int page, int pageSize, out int totalRow);
    }

    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
        public IEnumerable<Product> GetListProductByTag(string tagId, int page, int pageSize, out int totalRow)
        {
            var query = from  pt in DbContext.ProductTags join p in DbContext.Products
                        on pt.ProductID equals p.ID 
                        where pt.TagID == tagId
                        select p;
            totalRow = query.Count();

            return query.OrderByDescending(x => x.CreatedDate).Skip((page - 1) * pageSize).Take(pageSize);
        }
    }
}