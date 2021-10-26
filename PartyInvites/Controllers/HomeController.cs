using Microsoft.AspNetCore.Mvc;
using System.Linq;
using PartyInvites.Models;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        private DataContext context;
        public HomeController(DataContext ctx) => context = ctx;


        public IActionResult Index() => View();
        public IActionResult Respond() => View();

        [HttpPost]
        public IActionResult Respond(GuestResponse response)
        {
            context.Responses.Add(response);
            context.SaveChanges();

            return RedirectToAction(nameof(Thanks),
                new
                {
                    Name = response.Name,
                    WillAttend = response.WillAttend
                }
                );
        }

        public IActionResult Thanks(GuestResponse response) => View(response);

        public IActionResult ListResponses() => View(context.Responses.OrderByDescending(r => r.WillAttend));

        //public IActionResult ListResponses(string searchTerm = "555-123-5678") =>
        //View(context.Responses.Where(r => r.Phone == searchTerm).OrderBy(r => r.Email));
    }
}
