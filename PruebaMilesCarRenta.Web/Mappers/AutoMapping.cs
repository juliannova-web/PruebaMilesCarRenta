using AutoMapper;
using PruebaMilesCarRenta.Shared.Entities;
using PruebaMilesCarRenta.Web.DTO;

namespace PruebaMilesCarRenta.Web.Mappers
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Booking, BookingDTO>().ReverseMap();         
            CreateMap<Preference, PreferenceDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Vehicle, VehicleDTO>().ReverseMap();


        }
    }
}
