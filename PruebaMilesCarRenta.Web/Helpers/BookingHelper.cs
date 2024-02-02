using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PruebaMilesCarRenta.Shared.Entities;
using PruebaMilesCarRenta.Web.Data;
using PruebaMilesCarRenta.Web.DTO;

namespace PruebaMilesCarRenta.Web.Helpers
{
    public class BookingHelper : IBookingHelper
    {
        private readonly DataContext _context;

        public BookingHelper(DataContext context)
        {
            _context = context;
        }
        public async Task<BookingDTO> AddBookingAsync(BookingDTO bookingDTO)
        {
            var model = new Booking
            {
                
                UserID = bookingDTO.UserID,
                VehicleID = bookingDTO.VehicleID,
                Date = bookingDTO.Date,
                PaymentType = bookingDTO.PaymentType,
                Status = true,


            };

            _context.BOOKING.Add(model);
            await _context.SaveChangesAsync();


            return bookingDTO;
        }

		public async Task CancelBookingAsync(int id)
		{
			var booking = await _context.BOOKING
				.FirstOrDefaultAsync(m => m.Id == id);
            
			if (booking != null)
			{
				booking.Status = false;
				_context.BOOKING.Update(booking);
			}
			await _context.SaveChangesAsync();

		}

		public async Task<IEnumerable<BookingDTO>> GetBookingAsync()
        {
            var bookingsUser = await _context.BOOKING.ToListAsync();

            var bookingsUserDTO = from bookings in bookingsUser
                                  join vehicle in _context.VEHICLE on bookings.VehicleID equals vehicle.Id
                                  select new BookingDTO
                                  {
                                      Id = bookings.Id,
                                      UserID = bookings.UserID,
                                      VehicleID = bookings.VehicleID,
                                      Date = bookings.Date,
                                      PaymentType = bookings.PaymentType,
                                      Status = bookings.Status,
                                      Model = vehicle.Model,
                                      Brand = vehicle.Brand,
                                      Price = vehicle.Price,
                                  };

            var datos = bookingsUserDTO;



            return bookingsUserDTO;
        }

        public async Task<IEnumerable<BookingDTO>> GetBookingAsync(Guid UserId)
        {
            //var bookings = await _context.BOOKING.Where(x => x.UserID == UserId).ToListAsync();

            //var bookingsDTO = bookings.Select(v => new BookingDTO
            //{
            //    Id = v.Id,
            //    UserID = v.UserID,
            //    VehicleID = v.VehicleID,
            //    Date = v.Date,
            //    PaymentType = v.PaymentType,
            //    Status = v.Status,
            //}).ToList();

            //return bookingsDTO;



            var bookingsUser = await _context.BOOKING.Where(x => x.UserID == UserId && x.Status == true).ToListAsync();

            var bookingsUserDTO = from bookings in bookingsUser
                                    join vehicle in _context.VEHICLE on bookings.VehicleID equals vehicle.Id
                                    select new BookingDTO
                                    {
                                        Id = bookings.Id,
                                        UserID = bookings.UserID,
                                        VehicleID = bookings.VehicleID,
                                        Date = bookings.Date,
                                        PaymentType= bookings.PaymentType,
                                        Status = bookings.Status,
                                        Model = vehicle.Model,
                                        Brand = vehicle.Brand,
                                        Price = vehicle.Price,
                                    };

            var datos = bookingsUserDTO;



            return bookingsUserDTO;





        }

        public async Task<IEnumerable<BookingDTO>> GetBookingMayorBogotaAsync()
        {
            var bookingsUser = await _context.Users.Where(x => x.City == "Bogotá").ToListAsync();

            List<UserIdentDTO> users = new List<UserIdentDTO>();

            foreach (var item in bookingsUser)
            {
                if (int.Parse(item.YearOld) >= 40)
                {
                    var model = new UserIdentDTO
                    {
                        Id = Guid.Parse(item.Id),
                        Username = item.UserName,
                        YearOld = int.Parse(item.YearOld),
                        CityId = item.City


                    };
                    users.Add(model);
                }
               
            }


            var bookingsUserDTO = from user in users
                                  join booking in _context.BOOKING on user.Id equals booking.UserID
                                  select new BookingDTO
                                  {
                                      Id = booking.Id,
                                      UserID = booking.UserID,
                                      VehicleID = booking.VehicleID,
                                      Date = booking.Date,
                                      PaymentType = booking.PaymentType,
                                      Status = booking.Status,
                                      Usuario = user.Username,
                                  };

            var datos = bookingsUserDTO;



            return bookingsUserDTO;
        }

        public async Task<IEnumerable<BookingDTO>> GetBookingPaymentPDAsync()
        {
            var bookingsUser = await _context.BOOKING.Where(x => x.PaymentType == "PD").ToListAsync();

            var bookingsUserDTO = from bookings in bookingsUser
                                  join vehicle in _context.VEHICLE on bookings.VehicleID equals vehicle.Id
                                  select new BookingDTO
                                  {
                                      Id = bookings.Id,
                                      UserID = bookings.UserID,
                                      VehicleID = bookings.VehicleID,
                                      Date = bookings.Date,
                                      PaymentType = bookings.PaymentType,
                                      Status = bookings.Status,
                                      Model = vehicle.Model,
                                      Brand = vehicle.Brand,
                                      Price = vehicle.Price,
                                  };

            var datos = bookingsUserDTO;



            return bookingsUserDTO;
        }

        public async Task<IEnumerable<BookingDTO>> GetBookingPaymentPTAsync()
        {
            var bookingsUser = await _context.BOOKING.Where(x => x.PaymentType == "PT").ToListAsync();

            var bookingsUserDTO = from bookings in bookingsUser
                                  join vehicle in _context.VEHICLE on bookings.VehicleID equals vehicle.Id
                                  select new BookingDTO
                                  {
                                      Id = bookings.Id,
                                      UserID = bookings.UserID,
                                      VehicleID = bookings.VehicleID,
                                      Date = bookings.Date,
                                      PaymentType = bookings.PaymentType,
                                      Status = bookings.Status,
                                      Model = vehicle.Model,
                                      Brand = vehicle.Brand,
                                      Price = vehicle.Price,
                                  };

            var datos = bookingsUserDTO;



            return bookingsUserDTO;
        }
    }
}
