namespace S2_L2.Models
{
    public class Sala
    {
        public string Name { get; set; }
        public int SoldTickets{ get; set; }
        public int SoldReducedTickets { get; set; }
        public static int Capacity { get; set; }
    }
}
