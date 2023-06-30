using MachineTest.Data;
using MachineTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MachineTest.Controllers
{
    public class ProductController : Controller
    {
        private readonly MachineTestContext _context;
        public ProductController(MachineTestContext context)
        {
            _context = context;
        }

        public IActionResult Index(int? pageNumber)
        {
            //var products = _context.Products.Include("Categories");
            int pageSize = 10;
            var data = Paginated<Product>.CreatePage(_context.Products.Include("Categories").ToList(),pageNumber ?? 1, pageSize);
            return View(data);
        }


        [HttpGet]
        public IActionResult Create()
        {

            LoadCategory();

			return View();
        }

        [HttpPost]
        public IActionResult Create(Product mproduct)
        {
			ModelState.Remove("Categories");
			if (ModelState.IsValid)
            {
            _context.Products.Add(mproduct);
            _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mproduct);
        }

        [NonAction]
        void LoadCategory()
        {
            var cat = _context.Category.ToList();
            ViewBag.Categorylist = new SelectList(cat,"Id","Name");
        }


        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if(id != null)
            {
                NotFound();
            }
            LoadCategory();
            var p = _context.Products.Find(id);
            return View(p);
        }

        [HttpPost]
        public IActionResult Edit(Product mproduct)
        {
            ModelState.Remove("Categories");
            if(ModelState.IsValid)
            {
				_context.Products.Update(mproduct);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
            return View(mproduct);
        }



        [HttpGet]
        public IActionResult Delete(int? id)
        
        {
			if (id == null)
			{
				NotFound();
			}
			LoadCategory();
			var p = _context.Products.Find(id);
			return View(p);
		}

        
        [HttpPost, ActionName("Delete")]
        public IActionResult Deletecon(int? id)
        {
            if (id == null)
            {
                NotFound();
            }
            
            var p = _context.Products.Find(id);
            if (p != null)
            {
                _context.Products.Remove(p);
                _context.SaveChanges();
            return RedirectToAction("Index");
            }
            return View();

        }
    }
}
