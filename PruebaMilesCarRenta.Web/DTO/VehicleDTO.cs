using System.ComponentModel.DataAnnotations;

namespace PruebaMilesCarRenta.Web.DTO
{
    public class VehicleDTO
    {

        [Display(Name = "Id")]
        public Guid? Id { get; set; }

        [Display(Name = "Placa")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        public string NumberPlate { get; set; } = null!;

        [Display(Name = "Marca")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Brand { get; set; }

        [Display(Name = "Modelo")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Model { get; set; }

        [Display(Name = "Año")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int Year { get; set; }

        [Display(Name = "Cilindraje CC")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int CylinderCapacity { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public decimal Price { get; set; }

        [Display(Name = "Foto")]
        public string? NameImage { get; set; }

        [Display(Name = "Foto")]
        public string? ImageFullPath => NameImage == string.Empty
            ? $"~/images/noimage.png"
            : $"~/images/{NameImage}";

        [Display(Name = "Image")]
        public IFormFile? ImageFile { get; set; }

        [Display(Name = "Disponible")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public bool Available { get; set; }


    }
}
