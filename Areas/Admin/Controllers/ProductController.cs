using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Webtt.Data;
using Webtt.Models;

namespace Webtt.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    public class ProductController : Controller
    {
        private readonly DataContext dataContext;
        private readonly IMapper mapper;
        public ProductController(DataContext dataContext, IMapper mapper)
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<ProductModels> products = new List<ProductModels>();
            List<Product> productss = dataContext.Products.ToList();
            foreach(var item in productss)
            {
                var map = mapper.Map<ProductModels>(item);
                products.Add(map);
            }
            return View(products);
        }
        [HttpGet]
        private void CategoryList(object selectCategory = null)
        {
            ViewBag.categories = new SelectList(dataContext.Categories.ToList(), "CategoryId", "CategoryName", selectCategory);
        }
        public IActionResult Add()
        {
            ProductModels products = new ProductModels();
            //ViewData["CategoryId"] = new SelectList(dataContext.Categories, "CategoryId", "CategoryId");
            //ViewData["CategoryName"] = new SelectList(dataContext.Categories, "CategoryName", "CategoryName");
            CategoryList();
            return View(products);
        }
        [HttpPost]
        public IActionResult Add(ProductModels productModels, IFormFile photo)
        {
            var valid = dataContext.Products.Include(p => p.Category);
            if (ModelState.IsValid)
            {
                ProductModels newProduct = new ProductModels();
                if (photo == null || photo.Length == 0)
                {
                    newProduct.ProductImage = "abc.png";
                }
                else
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", photo.FileName);
                    var stream = new FileStream(path, FileMode.Create);
                    photo.CopyToAsync(stream);
                    newProduct.ProductImage = photo.FileName;
                }
                newProduct.ProductName = productModels.ProductName;               
                newProduct.ProductPrice = productModels.ProductPrice;
                newProduct.Description = productModels.Description;
                newProduct.CategoryId = productModels.CategoryId;
               
                Product p = new Product()
                {
                    ProductName = newProduct.ProductName,
                    ProductImage = newProduct.ProductImage,               
                    ProductPrice = newProduct.ProductPrice,
                    Description = newProduct.Description,
                    CategoryId = newProduct.CategoryId,
                };
                dataContext.Products.Add(p);
                dataContext.SaveChanges();
                return RedirectToAction("Index", "Product");
            }
            else
            {
                return View(productModels);
            }
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            //ProductModels oldProduct = productData.ProductList.FirstOrDefault(p => p.ProductId == id);
            Product product = dataContext.Products.FirstOrDefault(p => p.ProductId == id);
            ProductModels oldProduct = new ProductModels()
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                ProductPrice = product.ProductPrice,
                Description= product.Description,
                CategoryId= product.CategoryId
                
            };
            CategoryList();
            return View(oldProduct);
        }
        [HttpPost]
        public IActionResult Edit(int id, ProductModels productModels)
        {
            if (ModelState.IsValid)
            {
                Product p1 = dataContext.Products.FirstOrDefault(p => p.ProductId == id);
                p1.ProductName = productModels.ProductName;
                p1.ProductPrice = productModels.ProductPrice;
                p1.Description = productModels.Description;
                p1.CategoryId = productModels.CategoryId;
                dataContext.SaveChanges();
                ViewBag.Status = 1;
                return RedirectToAction("Index", "Product");
            }
            else
            {
                return View(productModels);
            }
        }
        public IActionResult Delete(int id)
        {         
            Product product = dataContext.Products.FirstOrDefault(p => p.ProductId == id);
            ProductModels oldProduct = new ProductModels()
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName, 
                ProductImage = product.ProductImage,
                Description = product.Description,
                ProductPrice = product.ProductPrice             
            };
            ViewBag.CategoryName = dataContext.Categories.FirstOrDefault(p => p.CategoryId == product.CategoryId).CategoryName;
            return View(oldProduct);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            //productData.ProductList.RemoveAll(p => p.ProductId == id);
            Product product = dataContext.Products.FirstOrDefault(p => p.ProductId == id);
            dataContext.Products.Remove(product);
            dataContext.SaveChanges();
            return RedirectToAction("Index", "Product");
        }
    }
}
