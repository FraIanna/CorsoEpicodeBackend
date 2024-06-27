using Microsoft.AspNetCore.Mvc;
using S2_L2.Models;
using System.Diagnostics;

namespace S2_L2.Controllers
{
    public class HomeController : Controller
    {

        public static List<Sala> halls = new List<Sala>()
        {
            new Sala() {Name = "Sala NORD"},
            new Sala() {Name = "Sala EST"},
            new Sala() {Name = "Sala SUD"}
        };

        private static List<Biglietto> tickets = new List<Biglietto>();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewData["Halls"] = halls;
            ViewData["Tickets"] = tickets;
            return View(halls);
        }

        [HttpGet]
        public IActionResult Selling()
        {
            ViewData["Halls"] = halls;
            return View(new Selling());
        }


        [HttpPost("SellingPost")]
        public IActionResult SellingPost(Selling model)
        {
            var utente = new Utente { Name = model.Nome, Surname = model.Cognome};
            Sala selectedHall = null;
            
            foreach (var hall in halls)
            {
                if (hall.Name == model.Sala )
                {
                    selectedHall = hall;
                    break;
                }
            }

            if (selectedHall != null && selectedHall.SoldTickets < Sala.Capacity)
            {
                var type = model.TipoBiglietto == "Ridotto" ? Biglietto.TicketType.Reduced : Biglietto.TicketType.Full;

                selectedHall.SoldTickets++;

                if (type == Biglietto.TicketType.Reduced)
                { 
                    selectedHall.SoldReducedTickets++;
                }

                tickets.Add(new Biglietto { Utente = utente, Sala = selectedHall, Type = type });
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Impossibile vendere il biglietto. La sala è piena.");
                return View("Selling", model);
            }

        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
