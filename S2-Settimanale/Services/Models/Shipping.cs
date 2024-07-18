using System.ComponentModel.DataAnnotations;

namespace S2_Settimanale.Services.Models
{
    public class Shipping
    {
        public int Id { get; set; }
        [Display(Name = "Numero Cliente")]
        public int ClienteId { get; set; }

        [Display(Name = "Data della spedizione")]
        public DateTime DataSpedizione { get; set; }
        public decimal Peso { get; set; }

        [Display(Name = "Città Di destinazione")]
        public string CittaDestinataria { get; set; }

        [Display(Name = "Indirizzo del destinatario")]
        public string IndirizzoDestinatario { get; set; }

        [Display(Name = "Nominativo Destinatario")]
        public string NominativoDestinatario { get; set; }

        [Display(Name = "Costo della spedizione")]
        public decimal CostoSpedizione { get; set; }

        [Display(Name = "Data della consegna prevista")]
        public DateTime DataConsegnaPrevista { get; set; }
    }
}
