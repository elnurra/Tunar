using Fiorello.Data;
using Fiorello.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiorello.Controllers
{
    public class ProductController:Controller
    {
        private readonly AppDbContext _context;
        public ProductController(AppDbContext context)
        {
            _context=context;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Product> products = await  _context.Products.Where(m=>!m.IsDeleted).Include(m=>m.Category).Include(m=>m.ProductImages).ToListAsync();
            return View(products);
        }
    }
}
