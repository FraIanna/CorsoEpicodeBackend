using System.ComponentModel.DataAnnotations;

namespace S2_Settimanale.Services.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(255)]
        public string Nome { get; set; }

        [Required]
        [StringLength(7)]
        public string Tipo { get; set; }

        [StringLength(16)]
        public string CodiceFiscale { get; set; }

        [StringLength(11)]
        public string PartitaIva { get; set; }

        [Required]
        [StringLength(255)]
        public string Indirizzo { get; set; }

        [Required]
        [StringLength(100)]
        public string Città { get; set; }

        [Required]
        [StringLength(5)]
        public string Cap { get; set; }

        [Required]
        [StringLength(13)]
        public string Telefono { get; set; }

        public List<string> Roles { get; set; } = [];
    }   


}
