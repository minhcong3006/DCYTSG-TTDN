﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webtt.Data;
using Webtt.Models;

namespace Webtt.Controllers
{
    public class NewsDetailController : Controller
    {
        private DataContext dataContext;
        IMapper mapper;
        public NewsDetailController(DataContext dataContext, IMapper mapper)
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
        }
        [HttpGet("NewsDetail/{name}")]
        public IActionResult Index(int id)
        {
            ViewBag.NewsRelate = ListRelatedNews(id);
            return View(dataContext.Newss.FirstOrDefault(p => p.NewsId == id));
        }
        public List<News> ListRelatedNews(int id)
        {
            var news = dataContext.Newss.Find(id);
            if (news == null)
            {
                return null;
            }
            return dataContext.Newss.Where(x => x.NewsId != id ).Take(2).ToList();
        }
    }
}
