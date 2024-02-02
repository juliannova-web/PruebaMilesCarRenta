using PruebaMilesCarRenta.Shared.Entities;
using PruebaMilesCarRenta.Web.DTO;

namespace PruebaMilesCarRenta.Web.Helpers
{
    public interface IVehicleHelper
    {
        Task<IEnumerable<VehicleDTO>> GetVehicleAsync();

        Task<VehicleDTO> AddVehicleAsync(VehicleDTO vehicleDTO);
    }
}
