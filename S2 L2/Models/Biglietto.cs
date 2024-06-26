namespace S2_L2.Models
{
    public class Biglietto
    {
        public enum TicketType
        {
            Full, 
            Reduced
        }
        public TicketType Type{ get; set; }
        public Sala Sala { get; set; }
        public Utente Utente { get; set; }
    }
}
