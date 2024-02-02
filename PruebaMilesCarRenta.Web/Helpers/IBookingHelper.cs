using PruebaMilesCarRenta.Shared.Entities;
using PruebaMilesCarRenta.Web.DTO;

namespace PruebaMilesCarRenta.Web.Helpers
{
    public interface IBookingHelper
    {
        Task<IEnumerable<BookingDTO>> GetBookingAsync();
        Task<IEnumerable<BookingDTO>> GetBookingAsync(Guid UserId);
        Task<BookingDTO> AddBookingAsync(BookingDTO bookingDTO);

		Task CancelBookingAsync(int id);

        Task<IEnumerable<BookingDTO>> GetBookingPaymentPTAsync();
        Task<IEnumerable<BookingDTO>> GetBookingPaymentPDAsync();

        Task<IEnumerable<BookingDTO>> GetBookingMayorBogotaAsync();
    }
}
