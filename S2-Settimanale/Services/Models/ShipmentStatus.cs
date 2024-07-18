namespace S2_Settimanale.Services.Models
{
    public class ShipmentStatus
    {
        public int Id { get; set; }
        public int IdSpedizione { get; set; }
        public DateTime DataAggiornamento { get; set; }
        public string Stato { get; set; }
        public string Luogo { get; set; }
        public string Descrizione { get; set; }
    }
}
