using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMilesCarRenta.Shared.Entities
{
    public class Booking
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Usuario")]
        public Guid UserID { get; set; }

        [Display(Name = "Vehiculo")]
        public Guid VehicleID { get; set; }

        [Display(Name = "Fecha Reserva")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime Date { get; set; }

        [Display(Name = "Tipo de Pago")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string PaymentType { get; set; }

        [Display(Name = "Tipo de Pago")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public bool Status { get; set; }

    }
}
