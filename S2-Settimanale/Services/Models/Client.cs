using System.ComponentModel.DataAnnotations;

namespace S2_Settimanale.Services.Models
{
    public class Client
    {
        [Required]
        [StringLength(100)]
        [Display(Name = "Nome Completo")]
        public required string Nome { get; set; }

        [Display(Name = "Scegli un opzione")]
        public bool Tipo { get; set; }

        [StringLength(16)]
        [Display(Name = "Codice Fiscale")]
        public string? CodiceFiscale { get; set; }

        [StringLength(11)]
        [Display(Name = "Partita Iva")]
        public string? PartitaIva { get; set; }

        [Required]
        [StringLength(255)]
        public required string Indirizzo { get; set; }

        [Required]
        [StringLength(100)]
        public required string Città { get; set; }

        [Required]
        [StringLength(5)]
        public required string Cap { get; set; }

        [Required]
        [StringLength(13)]
        public required string Telefono { get; set; }
    }
}
