using S2_Settimanale.Services.Models;

namespace S2_Settimanale.Services
{
    public interface IShippingService
    {
        Task<int> RegisterShippingAsync(Shipping model);
        Task<List<Shipping>> GetShippingTodayAsync();
        Task<int> GetAllshipmentsNotYetDelivered();
        Task<Dictionary<string, int>> GetShipmentsForeachCityAsync();
        Task<List<ShipmentStatus>> GetShipmentUpdateAsync(string codiceFiscalePartitaIva, int numeroSpedizione);
    }
}
