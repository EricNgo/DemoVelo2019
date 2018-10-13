using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

using System.Web.Mvc;
using TeduShop.Common;
using TeduShop.Model.Models;
using TeduShop.Service;
using TeduShop.Web.Models;

namespace TeduShop.Web.Controllers
{
    public class HomeController : Controller
    {
        IProductCategoryService _productCategoryService;
        IProductService _productService;
        ICommonService _commonService;
        public HomeController(IProductCategoryService productCategoryService,
            IProductService productService,
            ICommonService commonService)
        {
            _productCategoryService = productCategoryService;
            _productService = productService;
            _commonService = commonService;
        }

        [OutputCache(Duration = 3600, Location = System.Web.UI.OutputCacheLocation.Client)]
        public ActionResult Index()
        {
            var homeViewModel = new HomeViewModel();
            var lastestProductModel = _productService.GetLastest(4);
            var topSaleProductModel = _productService.GetHotProduct(2);
            var lastestProductViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(lastestProductModel);
            var topSaleProductViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(topSaleProductModel);
            homeViewModel.LastestProducts = lastestProductViewModel;
            homeViewModel.TopSaleProducts = topSaleProductViewModel;
            try
            {
                homeViewModel.Title = _commonService.GetSystemConfig(CommonConstants.HomeTitle).ValueString;
                homeViewModel.MetaKeyword = _commonService.GetSystemConfig(CommonConstants.HomeMetaKeyword).ValueString;
                homeViewModel.MetaDescription = _commonService.GetSystemConfig(CommonConstants.HomeMetaDescription).ValueString;
            }
            catch
            {

            }
            return View(homeViewModel);
        }

        [ChildActionOnly]
        [OutputCache(Duration = 3600)]
        public ActionResult Footer()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult Header()
        {
            var model = _productCategoryService.GetAll();
            var listProductCategoryViewModel = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(model);
            return PartialView(listProductCategoryViewModel);
        }

    }
}