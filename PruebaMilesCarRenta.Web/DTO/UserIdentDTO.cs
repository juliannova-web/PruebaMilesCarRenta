using System.ComponentModel.DataAnnotations;

namespace PruebaMilesCarRenta.Web.DTO
{
    public class UserIdentDTO
    {

        [Display(Name = "Id")]
        public Guid? Id { get; set; }

        [Display(Name = "Ciudad")]
        public string? CityId { get; set; }

        [Display(Name = "Edad")]
        [MaxLength(3, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int YearOld { get; set; }

        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Debes ingresar un correo válido.")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Username { get; set; }

    }
}
