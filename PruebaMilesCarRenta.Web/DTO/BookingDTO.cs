using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace PruebaMilesCarRenta.Web.DTO
{
    public class BookingDTO
    {
        [Display(Name = "Id")]
        public int? Id { get; set; }

        [Display(Name = "Usuario")]
        public Guid UserID { get; set; }

        [Display(Name = "Vehiculo")]
        public Guid VehicleID { get; set; }

        [Display(Name = "Fecha Reserva")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Display(Name = "Tipo de Pago")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string? PaymentType { get; set; }
        public IEnumerable<SelectListItem>? PaymentTypes { get; set; }

        [Display(Name = "Estado")]
        public bool? Status { get; set; }

        [Display(Name = "Modelo")]
        public string? Model { get; set; }

        [Display(Name = "Marca")]
        public string? Brand { get; set; }

        [Display(Name = "Precio")]
        public decimal? Price { get; set; }

        [Display(Name = "Usuario")]
        public string? Usuario { get; set; }



    }
}
