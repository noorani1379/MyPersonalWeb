using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPersonalWeb.DataModel;
using MyPersonalWeb.Models;
using System.Diagnostics;

namespace MyPersonalWeb.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;
        
        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Index2(Message message)
        {
            //Object mapping   
            // message.Created= DateTime.Now;  -->this coulde be or The default value directly in  our entits Model

            //Add to DataBase
            await _context.AddAsync(message);
            await _context.SaveChangesAsync();

            return RedirectToAction("Contact","Home");
        }


        [HttpGet]
        public IActionResult Contact(){ return View(); }
        
        [HttpPost]
        public async Task<IActionResult> Contact( string message, string name = "--", string email=null)
        {
            //Object mapping   
            Message entityModel = new()
            {
              Name = name,
              Content=message,
              Email = email,
              Created=DateTime.Now
            };

            //Add to DataBase
            await _context.AddAsync(entityModel);
            await _context.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index1));
            await Task.Delay(2000);
        }
        [Authorize]
        [AllowAnonymous]
        public async Task<IActionResult> Messages()
        {
            var db = await _context.Messages.ToListAsync();

            DTO dto = new()
            {
                Content = db

            };
            return View(dto);
        }

        public async Task<IActionResult> Delete(int memberId)
        {
            var getId= await _context.Messages.FirstOrDefaultAsync(p=>p.Id==memberId);
            _context.Messages.Remove(getId);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Messages));
        }

        [Route("")]
        public IActionResult Index1()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult Index2() { 
            return View();
        }

        [Route("About")]
        public IActionResult About()
        {
            
            return View();
        }

        public IActionResult AboutDetials()
        {
            return View();
        }
        [Route("Blog")]
        public IActionResult Blog()
        {
            return View();
        }
        public IActionResult BlogDetials()
        {
            return View();
        }
        [Route("Works")]
        public IActionResult Works()
        {
            return View();
        }
        public IActionResult WorksDetials()
        {
            return View();
        }
    }
}
