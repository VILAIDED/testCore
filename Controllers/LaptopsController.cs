using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using testCore.Data;
using testCore.Models;

namespace testCore.Controllers
{
    public class LaptopsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LaptopsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Laptops
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Laptop.Include(l => l.Brand);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Laptops/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laptop = await _context.Laptop
                .Include(l => l.Brand)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (laptop == null)
            {
                return NotFound();
            }

            return View(laptop);
        }

        // GET: Laptops/Create
        public IActionResult Create()
        {
           
            ViewData["BrandID"] = new SelectList(_context.Brand, "ID", "BrandName");
            return View();
        }

        // POST: Laptops/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
    /*    public async Task<IActionResult> Create([Bind("ID,BrandID,Price,LaptopName,Info,Amount")] Laptop laptop)
        {
            if (ModelState.IsValid)
            {
                _context.Add(laptop);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandID"] = new SelectList(_context.Brand, "ID", "ID", laptop.BrandID);
            return View(laptop);
        }*/
        
        [HttpPost]
        public async Task<IActionResult> Create([Bind("ID,BrandID,Price,LaptopName,Info,Amount")] Laptop laptop,IFormFile file)
        {
          
            if (ModelState.IsValid)
                {
                    _context.Add(laptop);
                    await _context.SaveChangesAsync();
                  
                string path = "";

                if (file != null)
                {
                    string fileName = Path.GetFileName(file.FileName);
                    path = Path.Combine(Directory.GetCurrentDirectory(), "Image", fileName);
                    Console.WriteLine(path);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                }
                LaptopImage image = new LaptopImage();
                image.ImagePath = file == null ? "" : path;
                image.LaptopId = laptop.ID;
                _context.LaptopImage.Add(image);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandID"] = new SelectList(_context.Brand, "ID", "ID", laptop.BrandID);
            return View(laptop);
        }

        // GET: Laptops/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laptop = await _context.Laptop.FindAsync(id);
            if (laptop == null)
            {
                return NotFound();
            }
            SelectList selectListItems = new SelectList(_context.Brand, "ID", "BrandName",laptop.BrandID);
           /* for(int i = 0; i < selectListItems.Items.C)
            foreach (SelectListItem item in selectListItems.Items)
            {
                if (item.Value ==  laptop.BrandID.ToString())
                {
                    item.Selected = true;
                }
     
            }*/
            ViewData["BrandID"] = selectListItems;
            return View(laptop);
        }

        // POST: Laptops/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,BrandID,Price,LaptopName,Info,Amount")] Laptop laptop,IFormFile file)
        {
            if (id != laptop.ID)
            {
                return NotFound();
            }
            String path = "";
            if (file != null)
            {
                string fileName = Path.GetFileName(file.FileName);
                path = Path.Combine(Directory.GetCurrentDirectory(), "Image", fileName);
                Console.WriteLine(path);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

            }
            LaptopImage image = new LaptopImage();
            image.ImagePath = file == null ? "" : path;
            image.LaptopId = laptop.ID;
            _context.LaptopImage.Add(image);
            await _context.SaveChangesAsync();
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(laptop);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LaptopExists(laptop.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandID"] = new SelectList(_context.Brand, "ID", "BrandName", laptop.BrandID);
            return View(laptop);
        }

        // GET: Laptops/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laptop = await _context.Laptop
                .Include(l => l.Brand)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (laptop == null)
            {
                return NotFound();
            }

            return View(laptop);
        }

        // POST: Laptops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var laptop = await _context.Laptop.FindAsync(id);
            _context.Laptop.Remove(laptop);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LaptopExists(int id)
        {
            return _context.Laptop.Any(e => e.ID == id);
        }
    }
}
