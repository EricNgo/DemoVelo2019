using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeduShop.Model.Models;
using TeduShop.Service;
using TeduShop.Web.Models;

namespace TeduShop.Web.Controllers
{
    public class StoreController : Controller
    {

        IProductCategoryService _productCategoryService;

        public StoreController(IProductCategoryService productCategoryService )
        {
           this._productCategoryService = productCategoryService;
    
        }


        // GET: Store

        [ChildActionOnly]
        public ActionResult FooterStore()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult HeaderStore()
        {
            var model = _productCategoryService.GetAll();
            var listProductCategoryViewModel = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(model);
            return PartialView(listProductCategoryViewModel);
        }

        [ChildActionOnly]
        public ActionResult CategoryStore()
        {
            var model = _productCategoryService.GetAll();
            var listProductCategoryViewModel = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(model);
            return PartialView(listProductCategoryViewModel);
        }
    }
}