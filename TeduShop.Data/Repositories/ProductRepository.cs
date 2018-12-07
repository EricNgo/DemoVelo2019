using System.Collections.Generic;
using TeduShop.Data.Infrastructure;
using TeduShop.Model.Models;
using System.Linq;
using System.Data.SqlClient;
using TeduShop.Common.ViewModels;


namespace TeduShop.Data.Repositories
{ 
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetListProductByTag(string tagId, int page, int pageSize, out int totalRow);
        IEnumerable<AllTagsViewModel> GetListProductByAllTag(IEnumerable<string> _tags, int page, int pageSize, out int totalRow);

    }

    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
        public IEnumerable<Product> GetListProductByTag(string tagId, int page, int pageSize, out int totalRow)
        {
            var query = from  pt in DbContext.ProductTags
                        join p in DbContext.Products
                        on pt.ProductID equals p.ID 
                        where pt.TagID == tagId
                        select p;
            totalRow = query.Count();

            return query.OrderByDescending(x => x.CreatedDate).Skip((page - 1) * pageSize).Take(pageSize);
        }

        public IEnumerable<AllTagsViewModel> GetListProductByAllTag(IEnumerable<string> _tags, int page, int pageSize, out int totalRow)
        {
            var query = new SqlParameter[]{
                new SqlParameter("@_tags",_tags)
            };
            totalRow = query.Count();
            return DbContext.Database.SqlQuery<AllTagsViewModel>("whereistag @_tags", query.OrderBy(x=>x.TypeName).Skip((page - 1) * pageSize).Take(pageSize));
            //return query.OrderByDescending(x => x.CreatedDate).Skip((page - 1) * pageSize).Take(pageSize);
        }


    }
}