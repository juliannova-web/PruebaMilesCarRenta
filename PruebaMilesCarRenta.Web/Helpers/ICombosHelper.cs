using Microsoft.AspNetCore.Mvc.Rendering;

namespace PruebaMilesCarRenta.Web.Helpers
{
    public interface ICombosHelper
    {
        IEnumerable<SelectListItem> GetCombosTiposDocumento();
        IEnumerable<SelectListItem> GetCombosCiudades();

        IEnumerable<SelectListItem> GetCombosTiposPagos();

    }
}
