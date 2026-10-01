using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Wimps
    {
        [Required(ErrorMessage = "Du måste ange namn")]
        [StringLength(100, ErrorMessage = "Namnet får vara högst 100 tecken")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Du måste ange en e-postadress")]
        [EmailAddress(ErrorMessage = "Ogiltig e-postadress")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$",
            ErrorMessage = "E-postadressen måste innehålla en domän, t.ex. namn@exempel.se")]
        public string email { get; set; } = string.Empty;

        public bool vatten { get; set; }
        public bool mat { get; set; }
        public bool ficklampa { get; set; }
        public bool batteri_radio { get; set; }

        [StringLength(10000, ErrorMessage = "Texten får inte vara mer än 10000 tecken")]
        public string? tips { get; set; }
    }
}