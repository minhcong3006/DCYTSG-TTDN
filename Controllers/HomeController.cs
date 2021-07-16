using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Webtt.Data;
using Webtt.Models;

namespace Webtt.Controllers
{
    public class HomeController : Controller
    {
        DataContext dataContext;
        IMapper mapper;

        public HomeController(DataContext dataContext, IMapper mapper)
        {

            this.dataContext = dataContext;
            this.mapper = mapper;
        }

       

        public IActionResult Index()
        {
            List<ProductModels> products = new List<ProductModels>();
            List<Product> productss = dataContext.Products.ToList();
            ViewBag.Categories = dataContext.Categories.ToList();
            foreach (var item in productss)
            {
                var map = mapper.Map<ProductModels>(item);
                products.Add(map);
            }
            ViewBag.ProductList = products;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendRecord(Contact contact, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                //return RedirectToAction(nameof(Index));
                ModelState.TryAddModelError("Contact", "Error");
                TempData["Error"] = "Vui lòng nhập đủ thông tin";
                
                return Redirect(returnUrl);
                //return View(returnUrl);
            }
            
            dataContext.Add(contact);
            await dataContext.SaveChangesAsync();
            return Redirect("Home/" + returnUrl);
            //return RedirectToAction(nameof(Index));
        }

        [HttpGet("CategoryProduct/{name}")]
        public IActionResult CategoryProduct(int id)
        {
            ViewBag.categoryName = dataContext.Categories.FirstOrDefault(p => p.CategoryId == id).CategoryName;
            return View(dataContext.Products.Where(p => p.CategoryId == id).ToList());
        }

        public IActionResult Search(string search)
        {
            List<Product> item = new List<Product>();
            if (search != null)
            { 
                if (item.Count() == 0)
                    ViewBag.message = "Không có kết quả tìm kiếm nào cho từ khóa '" + search+"'";
                item = dataContext.Products.Where(p => p.ProductName.ToLower().Contains(search.ToLower())).ToList();
                ViewBag.message = "Có " + item.Count()+ " kết quả tìm kiếm cho từ khóa '"+ search+"'";
            }
           
            return View(item);
        }

        public IActionResult AllProduct()
        {
            return View(dataContext.Products.ToList());
        }


        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult News()
        {
            return View(dataContext.Newss.ToList());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
