using Microsoft.EntityFrameworkCore;
using PruebaMilesCarRenta.Shared.Entities;
using PruebaMilesCarRenta.Shared.Enum;
using PruebaMilesCarRenta.Web.Helpers;

namespace PruebaMilesCarRenta.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;


        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }
        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckRolesAsync();
            await CheckUserAsync("CC", "123456789", "Admin", "Administrador", "Bogotá", "calle falsa 123", "40", "3000000000", "administrador_miles_car@yopmail.com", TypeUser.Admin);
            await CheckUserAsync("CC", "987654321", "User", "Usuario", "Medellín", "calle falsa 456", "20", "3000000001", "usuario_miles_car@yopmail.com", TypeUser.User);

            if (!(await _context.VEHICLE.AnyAsync()))
            {
                await CheckVehicleAsync("ABC111", "AUDI", "FX-205", 2021, 2000, 300000000, "carro1.png", true);
                await CheckVehicleAsync("ABC112", "AUDI", "AX-206", 2012, 1800, 200000000, "carro2.png", true);
                await CheckVehicleAsync("ABC113", "RENAULT", "BX-214", 2020, 1600, 30000000, "carro3.png", true);
                await CheckVehicleAsync("ABC114", "AUDI", "CX-258", 2020, 1800, 80000000, "carro4.png", true);
                await CheckVehicleAsync("ABC115", "RENAULT", "DX-214", 2015, 1600, 150000000, "carro5.png", true);
                await CheckVehicleAsync("ABC116", "MAZDA", "EX-201", 2022, 1800, 90000000, "carro6.png", true);
                await CheckVehicleAsync("ABC117", "MAZDA", "GX-200", 2015, 1800, 35000000, "carro7.png", true);
                await CheckVehicleAsync("ABC118", "FERRARI", "HX-285", 2010, 2000, 100000000, "carro8.png", true);
            }
        }

        private async Task<User> CheckUserAsync(
            string Tipo_Identificacion,
            string numberDocument,
            string name,
            string surname,
            string city,
            string address,
            string yearOld,
            string phone,
            string email,
            TypeUser userType)
        {
            User user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                user = new User
                {
                    TypeDocument = Tipo_Identificacion,
                    NumberDocument = numberDocument,
                    Name = name,
                    Surname = surname,
                    City = city,
                    Address = address,
                    YearOld = yearOld,
                    Email = email,
                    UserName = email,
                    Phone = phone,
                    TypeUser = userType,
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
            }

            return user;
        }

        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(TypeUser.Admin.ToString());
            await _userHelper.CheckRoleAsync(TypeUser.User.ToString());
        }

        private async Task<Vehicle> CheckVehicleAsync(

            string numberPlate,
            string brand,
            string model,
            int year,
            int cylinderCapacity,
            decimal price,
            string nameImage,
            bool available
            )
        {

            var vehicle = new Vehicle
            {
                Id = Guid.NewGuid(),
                NumberPlate = numberPlate,
                Brand = brand,
                Model = model,
                Year = year,
                CylinderCapacity = cylinderCapacity,
                Price = price,
                NameImage = nameImage,
                Available = available                

            };

            _context.VEHICLE.Add(vehicle);
            await _context.SaveChangesAsync();



            return vehicle;
        }


    }
}
