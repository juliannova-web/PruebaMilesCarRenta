using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PruebaMilesCarRenta.Shared.Entities;
using PruebaMilesCarRenta.Web.Data;
using PruebaMilesCarRenta.Web.DTO;
using PruebaMilesCarRenta.Web.Helpers;

namespace PruebaMilesCarRenta.Web.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly DataContext _context;
        private readonly IVehicleHelper _vehicleHelper;
        private readonly IUserHelper _userHelper;

        public VehiclesController(DataContext context, IVehicleHelper vehicleHelper, IUserHelper userHelper)
        {
            _context = context;
            _vehicleHelper = vehicleHelper;
            _userHelper = userHelper;
        }

        // GET: Vehicles
        public async Task<IActionResult> Index()
        {
            
            return View(await _vehicleHelper.GetVehicleAsync());
        }

        public async Task<IActionResult> VehiculeByUser()
        {
            var Usuario = User.Identity.Name;
            var usuario = await _userHelper.GetUserAsync(Usuario);
            Guid idGuid = new Guid(usuario.Id);

            return View(await _vehicleHelper.GetVehicleAsync(idGuid));
        }

        // GET: Vehicles/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.VEHICLE == null)
            {
                return NotFound();
            }

            var vehicle = await _context.VEHICLE
                .FirstOrDefaultAsync(m => m.Id == id);

			var Usuario = User.Identity.Name;
			var usuario = await _userHelper.GetUserAsync(Usuario);
			Guid idGuid = new Guid(usuario.Id);

			

            if (vehicle == null)
            {
                return NotFound();
            }
			_vehicleHelper.AddVehicleUserPreferencyAsync(idGuid, vehicle);
			return View(vehicle);
        }
        [Authorize(Roles = "Admin")]
        // GET: Vehicles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VehicleDTO vehicleDTO)
        {
            if (ModelState.IsValid)
            {
               
                await _vehicleHelper.AddVehicleAsync(vehicleDTO);

                return RedirectToAction(nameof(Index));
            }
            return View(vehicleDTO);
        }

        [Authorize(Roles = "Admin")]
        // GET: Vehicles/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.VEHICLE == null)
            {
                return NotFound();
            }

            var vehicle = await _context.VEHICLE.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return View(vehicle);
        }

        

     


        private bool VehicleExists(Guid id)
        {
          return (_context.VEHICLE?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
