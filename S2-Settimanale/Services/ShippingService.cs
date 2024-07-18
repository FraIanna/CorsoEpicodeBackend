using S2_Settimanale.Services.Models;
using System.Data.SqlClient;

namespace S2_Settimanale.Services
{
    public class ShippingService : IShippingService
    {
        private string connectionString;

        public ShippingService(IConfiguration config)
        {
            connectionString = config.GetConnectionString("AuthDb");
        }

        public async Task<int> RegisterShippingAsync(Shipping model)
        {
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string query =
                        @"INSERT INTO spedizioni (cliente_id, data_spedizione, peso, città_destinataria, indirizzo_destinatario, nominativo_destinatario, costo, data_consegna_prevista)
                             VALUES (@ClienteId, @DataSpedizione, @Peso, @CittaDestinataria, @IndirizzoDestinatario, 
                                     @NominativoDestinatario, @CostoSpedizione, @DataConsegnaPrevista);
                             SELECT SCOPE_IDENTITY();";

                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ClienteId", model.ClienteId);
                        cmd.Parameters.AddWithValue("@DataSpedizione", model.DataSpedizione);
                        cmd.Parameters.AddWithValue("@Peso", model.Peso);
                        cmd.Parameters.AddWithValue("@CittaDestinataria", model.CittaDestinataria);
                        cmd.Parameters.AddWithValue("@IndirizzoDestinatario", model.IndirizzoDestinatario);
                        cmd.Parameters.AddWithValue("@NominativoDestinatario", model.NominativoDestinatario);
                        cmd.Parameters.AddWithValue("@CostoSpedizione", model.CostoSpedizione);
                        cmd.Parameters.AddWithValue("@DataConsegnaPrevista", model.DataConsegnaPrevista);

                        return Convert.ToInt32(await cmd.ExecuteScalarAsync());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore durante la registrazione della spedizione", ex);
            }
        }

        public async Task<List<Shipping>> GetShippingTodayAsync()
        {
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string query =
                        @"SELECT * FROM Spedizioni 
                          WHERE CAST(data_consegna_prevista AS DATE) = CAST(GETDATE() AS DATE)";

                    using (var cmd = new SqlCommand(query, conn))
                    {
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            var spedizioni = new List<Shipping>();
                            while (await reader.ReadAsync())
                            {
                                var shipping = new Shipping
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                    ClienteId = reader.GetInt32(reader.GetOrdinal("cliente_id")),
                                    DataSpedizione = reader.GetDateTime(reader.GetOrdinal("data_spedizione")),
                                    Peso = reader.GetDecimal(reader.GetOrdinal("peso")),
                                    CittaDestinataria = reader.GetString(reader.GetOrdinal("città_destinataria")),
                                    IndirizzoDestinatario = reader.GetString(reader.GetOrdinal("indirizzo_destinatario")),
                                    NominativoDestinatario = reader.GetString(reader.GetOrdinal("nominativo_destinatario")),
                                    CostoSpedizione = reader.GetDecimal(reader.GetOrdinal("costo")),
                                    DataConsegnaPrevista = reader.GetDateTime(reader.GetOrdinal("data_consegna_prevista"))
                                };
                                spedizioni.Add(shipping);
                            }
                            return spedizioni;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore durante il recupero delle spedizioni in consegna oggi", ex);
            }
        }

        public async Task<int> GetAllshipmentsNotYetDelivered()
        {
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string query =
                        @"SELECT COUNT(*) FROM Spedizioni 
                          WHERE data_consegna_prevista > GETDATE()";

                    using (var cmd = new SqlCommand(query, conn))
                    {
                        return (int)await cmd.ExecuteScalarAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore durante il recupero del numero delle spedizioni in attesa di consegna", ex);
            }
        }

        public async Task<Dictionary<string, int>> GetShipmentsForeachCityAsync()
        {
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string query =
                        @"SELECT città_destinataria, COUNT(*) as NumeroSpedizioni
                          FROM Spedizioni 
                          GROUP BY città_destinataria";

                    using (var cmd = new SqlCommand(query, conn))
                    {
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            var result = new Dictionary<string, int>();
                            while (await reader.ReadAsync())
                            {
                                string citta = reader.GetString(reader.GetOrdinal("città_destinataria"));
                                int numeroSpedizioni = reader.GetInt32(reader.GetOrdinal("NumeroSpedizioni"));
                                result[citta] = numeroSpedizioni;
                            }
                            return result;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore durante il recupero del numero delle spedizioni per città", ex);
            }
        }

        public async Task<List<ShipmentStatus>> GetShipmentUpdateAsync(string codiceFiscalePartitaIva, int numeroSpedizione)
        {
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string query =
                        @"SELECT a.Id, a.IdSpedizione, a.DataAggiornamento, a.Stato, a.Luogo, a.Descrizione
                          FROM AggiornamentoSpedizione a
                          JOIN spedizioni s ON a.IdSpedizione = s.Id
                          JOIN clienti c ON s.cliente_id = c.Id
                          WHERE (c.CodiceFiscale = @CodiceFiscalePartitaIva OR c.PartitaIva = @CodiceFiscalePartitaIva)
                          AND s.Id = @NumeroSpedizione
                          ORDER BY a.DataAggiornamento DESC";

                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CodiceFiscalePartitaIva", codiceFiscalePartitaIva);
                        cmd.Parameters.AddWithValue("@NumeroSpedizione", numeroSpedizione);

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            var aggiornamenti = new List<ShipmentStatus>();
                            while (await reader.ReadAsync())
                            {
                                aggiornamenti.Add(new ShipmentStatus
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                    IdSpedizione = reader.GetInt32(reader.GetOrdinal("IdSpedizione")),
                                    DataAggiornamento = reader.GetDateTime(reader.GetOrdinal("DataAggiornamento")),
                                    Stato = reader.GetString(reader.GetOrdinal("Stato")),
                                    Luogo = reader.GetString(reader.GetOrdinal("Luogo")),
                                    Descrizione = reader.GetString(reader.GetOrdinal("Descrizione"))
                                });
                            }
                            return aggiornamenti;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore durante il recupero degli aggiornamenti della spedizione", ex);
            }
        }

    }
}
