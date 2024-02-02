using System.ComponentModel.DataAnnotations;

namespace PruebaMilesCarRenta.Shared.Entities
{
    public class Vehicle
    {
        [Display(Name = "Id")]
        public Guid Id { get; set; }

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
        [MaxLength(4, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int Year { get; set; }

        [Display(Name = "Cilindraje CC")]
        [MaxLength(4, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int CylinderCapacity { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public decimal Price { get; set; }

        [Display(Name = "Foto")]
        public string? NameImage { get; set; }

        [Display(Name = "Foto")]
        public string ImageFullPath => NameImage == string.Empty
            ? $"~/images/noimage.png"
            : $"~/images/{NameImage}";

        [Display(Name = "Disponible")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public bool Available { get; set; }

    }
}
