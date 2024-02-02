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
    public class VehiclesController : Controller
    {
        private readonly DataContext _context;
        private readonly IVehicleHelper _vehicleHelper;

        public VehiclesController(DataContext context, IVehicleHelper vehicleHelper)
        {
            _context = context;
            _vehicleHelper = vehicleHelper;
        }

        // GET: Vehicles
        public async Task<IActionResult> Index()
        {
            return View(await _vehicleHelper.GetVehicleAsync());
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
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

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
                // Procesar el archivo de imagen si está presente
                //if (vehicleDTO.ImageFile != null && vehicleDTO.ImageFile.Length > 0)
                //{
                //    // Guardar el archivo de imagen en el servidor o en la base de datos
                //    //var nombreArchivo = await _fileHelper.UploadFileAsync(vehicleDTO.ImageFile, "vehicles");
                //    //vehicleDTO.NameImage = nombreArchivo;
                //}

                // Agregar el vehículo utilizando el helper
                await _vehicleHelper.AddVehicleAsync(vehicleDTO);

                return RedirectToAction(nameof(Index));
            }
            return View(vehicleDTO);
        }


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

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,NumberPlate,Brand,Model,Year,CylinderCapacity,Price,ImageId,Available")] Vehicle vehicle)
        {
            if (id != vehicle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleExists(vehicle.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vehicle);
        }

        // GET: Vehicles/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.VEHICLE == null)
            {
                return NotFound();
            }

            var vehicle = await _context.VEHICLE
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.VEHICLE == null)
            {
                return Problem("Entity set 'DataContext.VEHICLE'  is null.");
            }
            var vehicle = await _context.VEHICLE.FindAsync(id);
            if (vehicle != null)
            {
                _context.VEHICLE.Remove(vehicle);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleExists(Guid id)
        {
          return (_context.VEHICLE?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
