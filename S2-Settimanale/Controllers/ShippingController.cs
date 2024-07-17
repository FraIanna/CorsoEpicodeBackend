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
    }
}
