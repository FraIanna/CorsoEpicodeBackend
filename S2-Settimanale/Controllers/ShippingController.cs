using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using S2_Settimanale.Services;
using S2_Settimanale.Services.Models;

namespace S2_Settimanale.Controllers
{
    [Authorize]
    public class ShippingController : Controller
    {
        private readonly IShippingService _shippingService;

        public ShippingController(IShippingService shippingService)
        {
            _shippingService = shippingService;
        }

        public IActionResult RegisterShipping()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterShipping(Shipping shipping)
        {
            try
            {
                int shippingId = await _shippingService.RegisterShippingAsync(shipping);

                if (shippingId < 0) 
                { 
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex) {
                ModelState.AddModelError(string.Empty, "Si è verificato un errore durante la registrazione della spedizione.");
            }
            return View(shipping);
        }

        public async Task<IActionResult> ShippingToday()
        {
            try
            {
                var spedizioni = await _shippingService.GetShippingTodayAsync();
                return View(spedizioni);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Si è verificato un errore durante il recupero delle spedizioni in consegna oggi.");
                return View(new List<Shipping>());
            }
        }

        public async Task<IActionResult> GetShipmentsNotYetDelivered()
        {
            try
            {
                int numeroSpedizioni = await _shippingService.GetAllshipmentsNotYetDelivered();
                ViewBag.NumeroSpedizioni = numeroSpedizioni;
                return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Si è verificato un errore durante il recupero del numero delle spedizioni in attesa di consegna.");
                return View();
            }
        }

        public async Task<IActionResult> NumberOfShipmentsForeachCity()
        {
            try
            {
                var spedizioniPerCitta = await _shippingService.GetShipmentsForeachCityAsync();
                return View(spedizioniPerCitta);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Si è verificato un errore durante il recupero del numero delle spedizioni per città.");
                return View(new Dictionary<string, int>());
            }
        }

        [AllowAnonymous]
        public IActionResult VerifyShipmentStatus()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> VerifyShipmentStatus(string codiceFiscalePartitaIva, int numeroSpedizione)
        {
            try
            {
                var aggiornamenti = await _shippingService.GetShipmentUpdateAsync(codiceFiscalePartitaIva, numeroSpedizione);
                return View("ShipmentDetails", aggiornamenti);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Si è verificato un errore durante il recupero degli aggiornamenti della spedizione.");
                return View();
            }
        }

    }
}
