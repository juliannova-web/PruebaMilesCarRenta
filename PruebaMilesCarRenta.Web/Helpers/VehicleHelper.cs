using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PruebaMilesCarRenta.Shared.Entities;
using PruebaMilesCarRenta.Web.Data;
using PruebaMilesCarRenta.Web.DTO;

namespace PruebaMilesCarRenta.Web.Helpers
{
    public class VehicleHelper : IVehicleHelper
    {
        private readonly DataContext _context;

        public VehicleHelper(DataContext context)
        {
            _context = context;
        }

        public async Task<VehicleDTO> AddVehicleAsync(VehicleDTO vehicleDTO)
        {
            Guid Id = Guid.NewGuid();
            //var cantidadVehicles = _context.VEHICLE.Count();
            //var nombre = vehicleDTO.ImageFile.Name;


            var model = new Vehicle
            {
                //Id = Id,
                //NumberPlate = vehicleDTO.NumberPlate,
                //Brand = vehicleDTO.Brand,
                //Model = vehicleDTO.Model,
                //Year = vehicleDTO.Year,
                //CylinderCapacity = vehicleDTO.CylinderCapacity,
                //Price = vehicleDTO.Price,
                //NameImage = vehicleDTO.ImageFile.Name,
                //Available = vehicleDTO.Available,


            };

            _context.VEHICLE.Add(model);
            await _context.SaveChangesAsync();


            return vehicleDTO;

        }

        public async Task<IEnumerable<VehicleDTO>> GetVehicleAsync()
        {
            var vehicles = await _context.VEHICLE.ToListAsync();

            var vehiclesDTO = vehicles.Select(v => new VehicleDTO
            {
                //Id= v.Id,
                //NumberPlate = v.NumberPlate,
                //Brand = v.Brand,
                //Model = v.Model,
                //Year = v.Year,
                //CylinderCapacity = v.CylinderCapacity,
                //Price = v.Price,
                //NameImage = v.NameImage,
                //Available = v.Available
            }).ToList();

            return vehiclesDTO;
        }
    }
}
