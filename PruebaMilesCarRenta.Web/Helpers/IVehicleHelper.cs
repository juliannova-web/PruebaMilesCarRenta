using PruebaMilesCarRenta.Shared.Entities;
using PruebaMilesCarRenta.Web.DTO;

namespace PruebaMilesCarRenta.Web.Helpers
{
    public interface IVehicleHelper
    {
        Task<IEnumerable<VehicleDTO>> GetVehicleAsync();
        Task<IEnumerable<VehicleDTO>> GetVehicleAsync(Guid UserId);

		Task AddVehicleUserPreferencyAsync(Guid UserId, Vehicle vehicle);
		Task<VehicleDTO> AddVehicleAsync(VehicleDTO vehicleDTO);
    }
}
