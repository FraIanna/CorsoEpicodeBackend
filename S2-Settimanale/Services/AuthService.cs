using S2_Settimanale.Services.Models;
using System.Data.SqlClient;

namespace S2_Settimanale.Services
{
    public class AuthService : IAuthService
    {
        private string connectionString;

        private const string LOGIN_COMMAND = "SELECT Id FROM Users WHERE Username = @user AND Password = @pass";
        private const string ROLES_COMMAND = "SELECT RoleName FROM Roles ro JOIN UserRoles ur ON ro.Id = ur.RoleId WHERE UserId = @id";

        public AuthService(IConfiguration config)
        {
            connectionString = config.GetConnectionString("AuthDb");
        }

        public User Login(string username, string password)
        {
            try
            {
                using var conn = new SqlConnection(connectionString);
                conn.Open();
                using var cmd = new SqlCommand(LOGIN_COMMAND, conn);
                cmd.Parameters.AddWithValue("@user", username);
                cmd.Parameters.AddWithValue("@pass", password);
                using var r = cmd.ExecuteReader();
                if (r.Read())
                {
                    var u = new User { Id = r.GetInt32(0), Password = password, UserName = username };
                    r.Close();
                    using var roleCmd = new SqlCommand(ROLES_COMMAND, conn);
                    roleCmd.Parameters.AddWithValue("@id", u.Id);
                    using var re = roleCmd.ExecuteReader();
                    while (re.Read())
                    {
                        u.Roles.Add(re.GetString(0));
                    }
                    return u;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore durante il login", ex);
            }

            return null;
        }

        public async Task<int> RegisterClientAsync(Client model)
        {
            try
            {
                using var conn = new SqlConnection(connectionString);
                await conn.OpenAsync();
                string clienteQuery = 
                    @"INSERT INTO clienti (Nome, Tipo, CodiceFiscale, PartitaIva, Telefono, Indirizzo, Città, Cap) 
                  VALUES (@Nome, @Tipo, @CodiceFiscale, @PartitaIva, @Telefono, @Indirizzo, @Città, @Cap);
                  SELECT SCOPE_IDENTITY();";
                using var cmd = new SqlCommand(clienteQuery, conn);
                cmd.Parameters.AddWithValue("@Nome", model.Nome);
                cmd.Parameters.AddWithValue("@Tipo", model.Tipo ? 1 : 0);
                cmd.Parameters.AddWithValue("@CodiceFiscale", model.CodiceFiscale ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@PartitaIva", model.PartitaIva ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Telefono", model.Telefono);
                cmd.Parameters.AddWithValue("@Indirizzo", model.Indirizzo);
                cmd.Parameters.AddWithValue("@Città", model.Città);
                cmd.Parameters.AddWithValue("@Cap", model.Cap);

                int newClientId = Convert.ToInt32(await cmd.ExecuteScalarAsync());
                return newClientId;
            }
            catch (Exception ex)
            {
                throw new Exception("Errore durante la registrazione del cliente", ex);
            }
        }
    }
}
