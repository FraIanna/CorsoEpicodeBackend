using S2_Settimanale.Services.Models;

namespace S2_Settimanale.Services
{
    public interface IShippingService
    {
        Task<int> RegisterShippingAsync(Shipping model);
    }
}
