using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using testCore.Models;
using Newtonsoft.Json;
using testCore.Data;

namespace testCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult MyCard(){
            List<Item> itemList = new List<Item>();
             string json = HttpContext.Session.GetString("Cart");
            if(json != null){
            itemList = JsonConvert.DeserializeObject<List<Item>>(json);
            ViewData["itemList"] = itemList;
            }
            return View();
        }
        public  async Task<IActionResult> Order([Bind("CustomerName,Email,Phone")]Bill bill){
            if(ModelState.IsValid){
              //  double price = 0;
                bill.OrderDate = DateTime.Now;
                _context.Add(bill);
              await  _context.SaveChangesAsync();

                string json = HttpContext.Session.GetString("Cart");
                List<Item> itemList = JsonConvert.DeserializeObject<List<Item>>(json);

                foreach(Item item in itemList){
                    BillInfo billInfo = new BillInfo
                    {
                        BillID = bill.ID,
                        Quanlity = item.Quanlity,
                        LaptopId = item.Laptop.ID,
                        Price = item.Laptop.Price * item.Quanlity
                    };
                    
                    _context.BillInfos.Add(billInfo);
                     await  _context.SaveChangesAsync();
                }
                HttpContext.Session.Clear();
            }
            return RedirectToAction(nameof(Index));
        }
        public IActionResult AddToCard(int Id)
        {

            List<Item> itemList = new List<Item>();
            var laptop = _context.Laptop.Find(Id);
            if (HttpContext.Session.GetString("Cart")!= null)
            {
                string json = HttpContext.Session.GetString("Cart");
                itemList = JsonConvert.DeserializeObject<List<Item>>(json);
            }
            itemList.Add(new Item
            {
                Laptop = laptop,
                Quanlity = 1
            });
            HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(itemList));
            return RedirectToAction("Index", "Laptops");

        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
