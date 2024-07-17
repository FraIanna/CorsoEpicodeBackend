﻿using S2_Settimanale.Services.Models;
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

        public async Task<Shipping> GetSpedizioneByIdAsync(int id)
        {
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string query = "SELECT * FROM Spedizioni WHERE Id = @Id";

                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return new Shipping
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
                            }
                        }
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Errore durante il recupero della spedizione", ex);
            }
        }
    }
}
