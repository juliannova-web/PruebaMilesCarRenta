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
            var nombre = vehicleDTO.ImageFile.FileName;


            var model = new Vehicle
            {
                Id = Id,
                NumberPlate = vehicleDTO.NumberPlate,
                Brand = vehicleDTO.Brand,
                Model = vehicleDTO.Model,
                Year = vehicleDTO.Year,
                CylinderCapacity = vehicleDTO.CylinderCapacity,
                Price = vehicleDTO.Price,
                NameImage = vehicleDTO.ImageFile.FileName,
                Available = vehicleDTO.Available,


            };

            _context.VEHICLE.Add(model);
            await _context.SaveChangesAsync();


            return vehicleDTO;

        }

		public async Task AddVehicleUserPreferencyAsync(Guid UserId, Vehicle vehicle)
		{

			var model = new Preference
			{
				
				UserID = UserId,
				Brand = vehicle.Brand,
				Model = vehicle.Model,
				Year = vehicle.Year,
				CylinderCapacity = vehicle.CylinderCapacity,
				Price = vehicle.Price


			};

			_context.PREFRENCE.Add(model);
			await _context.SaveChangesAsync();


			return ;
		}

		public async Task<IEnumerable<VehicleDTO>> GetVehicleAsync()
        {
            var vehicles = await _context.VEHICLE.ToListAsync();

            var vehiclesDTO = vehicles.Select(v => new VehicleDTO
            {
                Id = v.Id,
                NumberPlate = v.NumberPlate,
                Brand = v.Brand,
                Model = v.Model,
                Year = v.Year,
                CylinderCapacity = v.CylinderCapacity,
                Price = v.Price,
                NameImage = v.NameImage,
                Available = v.Available
            }).ToList();

            return vehiclesDTO;
        }

        public async Task<IEnumerable<VehicleDTO>> GetVehicleAsync(Guid UserId)
        {
           
            List<Preference> preferenciasUsuario = _context.PREFRENCE
                                            .Where(p => p.UserID == UserId) // Suponiendo que tienes el ID del usuario
                                            .ToList();

            if(preferenciasUsuario.Count > 0)
            {

				var vehiculosSeleccionados = new List<Vehicle>();

				foreach (var preferencia in preferenciasUsuario)
				{
					vehiculosSeleccionados.AddRange(_context.VEHICLE
						.Where(v =>
							v.Brand == preferencia.Brand ||
							v.Model == preferencia.Model ||
							v.Year == preferencia.Year ||
							v.CylinderCapacity == preferencia.CylinderCapacity ||
							v.Price == preferencia.Price
						)
						.ToList());
				}

                vehiculosSeleccionados = vehiculosSeleccionados.Distinct().ToList();
				//List<Vehicle> vehiculosSeleccionados = _context.VEHICLE
				//                                .Where(v =>
				//                                    preferenciasUsuario.Any(p =>
				//                                        v.Brand == p.Brand ||
				//                                        v.Model == p.Model ||
				//                                        v.Year == p.Year ||
				//                                        v.CylinderCapacity == p.CylinderCapacity ||
				//                                        v.Price == p.Price
				//                                    )
				//                                )
				//                          .ToList();

				var vehiclesUserDTO = vehiculosSeleccionados.Select(v => new VehicleDTO
                {
                    Id = v.Id,
                    NumberPlate = v.NumberPlate,
                    Brand = v.Brand,
                    Model = v.Model,
                    Year = v.Year,
                    CylinderCapacity = v.CylinderCapacity,
                    Price = v.Price,
                    NameImage = v.NameImage,
                    Available = v.Available
                }).ToList();

                return vehiclesUserDTO;
            }

            var vehicles = await _context.VEHICLE.ToListAsync();

            var vehiclesDTO = vehicles.Select(v => new VehicleDTO
            {
                Id = v.Id,
                NumberPlate = v.NumberPlate,
                Brand = v.Brand,
                Model = v.Model,
                Year = v.Year,
                CylinderCapacity = v.CylinderCapacity,
                Price = v.Price,
                NameImage = v.NameImage,
                Available = v.Available
            }).ToList();

            return vehiclesDTO;

           
        }
    }
}
