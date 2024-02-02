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

        public IEnumerable<SelectListItem> GetCombosCiudades()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Insert(0, new SelectListItem
            {
                Text = "Seleccione una ciudad",
                Value = "0"
            });
            list.Insert(1, new SelectListItem
            {
                Text = "Bogotá",
                Value = "Bogotá"
            });
            list.Insert(2, new SelectListItem
            {
                Text = "Medellín",
                Value = "Medellín"
            });
            list.Insert(3, new SelectListItem
            {
                Text = "Cartagena",
                Value = "Cartagena"
            });
            list.Insert(4, new SelectListItem
            {
                Text = "Cali",
                Value = "Cali"
            });           
            list.Insert(5, new SelectListItem
            {
                Text = "Barranquilla",
                Value = "Barranquilla"
            });
            list.Insert(6, new SelectListItem
            {
                Text = "Villavicencio",
                Value = "Villavicencio"
            });
            list.Insert(7, new SelectListItem
            {
                Text = "Bucaramanga",
                Value = "Bucaramanga"
            });
            list.Insert(8, new SelectListItem
            {
                Text = "Tunja",
                Value = "Tunja"
            });
            return list;
        }



    }
}
