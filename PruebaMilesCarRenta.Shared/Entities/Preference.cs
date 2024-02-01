using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMilesCarRenta.Shared.Entities
{
    public class Preference
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Usuario")]
        public Guid UserID { get; set; }

        [Display(Name = "Marca")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        public string Brand { get; set; }

        [Display(Name = "Modelo")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        public string Model { get; set; }

        [Display(Name = "Año")]
        [MaxLength(4, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        public int Year { get; set; }

        [Display(Name = "Cilindraje CC")]
        [MaxLength(4, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        public int CylinderCapacity { get; set; }

        [Display(Name = "Precio")]
        [Range(typeof(decimal), "0.01", "9999999999999999.99", ErrorMessage = "El valor debe estar entre 0.01 y 9999999999999999.99")]
        public decimal Price { get; set; }


    }
}
