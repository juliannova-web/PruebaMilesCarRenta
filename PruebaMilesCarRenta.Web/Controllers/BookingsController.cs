using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PruebaMilesCarRenta.Shared.Entities;
using PruebaMilesCarRenta.Web.Data;
using PruebaMilesCarRenta.Web.DTO;
using PruebaMilesCarRenta.Web.Helpers;

namespace PruebaMilesCarRenta.Web.Controllers
{
    public class BookingsController : Controller
    {
        private readonly DataContext _context;
        private readonly ICombosHelper _combosHelper;
        private readonly IBookingHelper _bookingHelper;
        private readonly IUserHelper _userHelper;

        public BookingsController(DataContext context, ICombosHelper combosHelper, IBookingHelper bookingHelper, IUserHelper userHelper)
        {
            _context = context;
            _combosHelper = combosHelper;
            _bookingHelper = bookingHelper;
            _userHelper = userHelper;
        }

        // GET: Bookings
        public async Task<IActionResult> Index()
        {
            var Usuario = User.Identity.Name;
            var usuario = await _userHelper.GetUserAsync(Usuario);
            Guid idGuid = Guid.Parse(usuario.Id);

            if (User.IsInRole("Admin"))
            {
                return View(await _bookingHelper.GetBookingAsync());
            }

            return View(await _bookingHelper.GetBookingAsync(idGuid));
                      

        }

        

        public async Task<IActionResult> GetBookingAsync()
        {
            var Usuario = User.Identity.Name;
            var usuario = await _userHelper.GetUserAsync(Usuario);
            Guid idGuid = Guid.Parse(usuario.Id);

            return View(await _bookingHelper.GetBookingAsync(idGuid));


        }

        public async Task<IActionResult> ListPaymentPT()
        {
            var Usuario = User.Identity.Name;
            var usuario = await _userHelper.GetUserAsync(Usuario);
            Guid idGuid = Guid.Parse(usuario.Id);


            return View(await _bookingHelper.GetBookingPaymentPTAsync());

        }
        public async Task<IActionResult> ListPaymentPD()
        {
            var Usuario = User.Identity.Name;
            var usuario = await _userHelper.GetUserAsync(Usuario);
            Guid idGuid = Guid.Parse(usuario.Id);


            return View(await _bookingHelper.GetBookingPaymentPDAsync());

        }

        public async Task<IActionResult> ListPaymentMayorBogota()
        {
            var Usuario = User.Identity.Name;
            var usuario = await _userHelper.GetUserAsync(Usuario);
            Guid idGuid = Guid.Parse(usuario.Id);


            return View(await _bookingHelper.GetBookingMayorBogotaAsync());

        }

        // GET: Bookings/Create
        public async Task<IActionResult> Create(Guid vehicleID)
        {

            var Usuario = User.Identity.Name;
            var usuario = await _userHelper.GetUserAsync(Usuario);
            Guid idGuid = Guid.Parse(usuario.Id);

            var model = new BookingDTO
            {
                Id = 0,
                PaymentTypes = _combosHelper.GetCombosTiposPagos(),
                Date = DateTime.Now.Date,
                VehicleID = vehicleID,
                UserID = idGuid,
                Status = true
            };

            return View(model);
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookingDTO bookingDTO)
        {
            if (ModelState.IsValid)
            {
                


               await _bookingHelper.AddBookingAsync(bookingDTO);
                return RedirectToAction(nameof(Index));
            }
            bookingDTO.Date = DateTime.Now.Date;
            bookingDTO.PaymentTypes = _combosHelper.GetCombosTiposPagos();
            return View(bookingDTO);
        }

        
        // GET: Bookings/Delete/5
        public async Task<IActionResult> Cancel(int id)
        {
            if (id == null || _context.BOOKING == null)
            {
                return NotFound();
            }
         
             await _bookingHelper.CancelBookingAsync(id);

			return RedirectToAction(nameof(Index));
		}

        
        private bool BookingExists(int id)
        {
          return (_context.BOOKING?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
