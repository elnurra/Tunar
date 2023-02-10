﻿using Fiorello.Data;
using Fiorello.Models;
using Fiorello.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace Fiorello.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task <IActionResult> Index()
        {
            IEnumerable<Slider> sliders = await _context.Sliders.Where(m => !m.IsDeleted).ToListAsync();
            SliderDetail sliderDetail= await _context.SliderDetails.Where(m=>!m.IsDeleted).FirstOrDefaultAsync();
            IEnumerable <Category> categories = await _context.Categories.Where(m=>!m.IsDeleted).ToListAsync();
            IEnumerable<Product> products = await _context.Products.Where(m => !m.IsDeleted).Include(m=>m.Category).Include(m=>m.ProductImages).ToListAsync();
            IEnumerable<Blog> blogs = await _context.Blogs.Where(m => !m.IsDeleted).ToListAsync();
            HomeVM model = new HomeVM()
            {
                SliderDetail = sliderDetail,
                Sliders = sliders,
                Categories = categories,
                Products = products,
                Blogs = blogs
            };
            return View(model);
        }

    
 
    }
}
