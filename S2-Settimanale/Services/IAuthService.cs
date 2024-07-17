using S2_Settimanale.Services.Models;
namespace S2_Settimanale.Services
{
    public interface IAuthService
    {
        User Login(string username, string password);
        Task<int> RegisterClientAsync(Client model);
    }
}
