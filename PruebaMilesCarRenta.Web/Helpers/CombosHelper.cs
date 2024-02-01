using Microsoft.AspNetCore.Mvc.Rendering;
using PruebaMilesCarRenta.Web.Data;

namespace PruebaMilesCarRenta.Web.Helpers
{
    public class CombosHelper : ICombosHelper
    {
        private readonly DataContext _context;

        public CombosHelper(DataContext context)
        {
            _context = context;
        }
     

        public IEnumerable<SelectListItem> GetCombosTiposDocumento()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Insert(0, new SelectListItem
            {
                Text = "Seleccione un tipo de Identificación",
                Value = "0"
            });
            list.Insert(1, new SelectListItem
            {
                Text = "Cédula",
                Value = "CC"
            });
            list.Insert(2, new SelectListItem
            {
                Text = "Pasaporte",
                Value = "PA"
            });
            list.Insert(3, new SelectListItem
            {
                Text = "Cédula de extrangeria",
                Value = "CE"
            });
            return list;
        }



    }
}
