using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaMilesCarRenta.Shared.Entities;
using PruebaMilesCarRenta.Shared.Enum;
using PruebaMilesCarRenta.Web.Data;
using PruebaMilesCarRenta.Web.DTO;
using PruebaMilesCarRenta.Web.Helpers;

namespace PruebaMilesCarRenta.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserHelper _userHelper;
        private readonly DataContext _context;
       
        private readonly ICombosHelper _combosHelper;

        public AccountController(IUserHelper userHelper, DataContext context, ICombosHelper combosHelper)
        {
            _userHelper = userHelper;
            _context = context;
            _combosHelper = combosHelper;
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var usuariosDTO = await _context.Users.ToListAsync();

            return View(usuariosDTO);
        }


        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Account");
            }

            return View(new LoginDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO model)
        {
            if (ModelState.IsValid)
            {
                Microsoft.AspNetCore.Identity.SignInResult result = await _userHelper.LoginAsync(model);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Email o contraseña incorrectos.");
            }

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _userHelper.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }


      
        public async Task<IActionResult> Register()
        {
            UserDTO model = new UserDTO
            {
                TypeUser = TypeUser.User,
                TypesDocument = _combosHelper.GetCombosTiposDocumento(),
                Cities = _combosHelper.GetCombosCiudades(),
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserDTO model)
        {
            if (ModelState.IsValid)
            {


                User user = await _userHelper.AddUserAsync(model);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Este correo ya está siendo usado.");
                    model.TypesDocument = _combosHelper.GetCombosTiposDocumento();
                    model.Cities = _combosHelper.GetCombosCiudades();
                    return View(model);
                }

                return RedirectToAction("Index", "Account");

            }

            model.TypesDocument = _combosHelper.GetCombosTiposDocumento();
            model.Cities = _combosHelper.GetCombosCiudades();
            return View(model);
        }


        public async Task<IActionResult> ChangePassword(Guid id)
        {

            var model = new ChangePasswordDTO
            {
                Usuario_Id = id
            };



            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordDTO model)
        {
            if (ModelState.IsValid)
            {
                //var user = await _userHelper.GetUserAsync(User.Identity.Name);

                var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == model.Usuario_Id.ToString());

                if (user != null)
                {
                    var result = await _userHelper.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Account");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, result.Errors.FirstOrDefault().Description);
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "User no found.");
                }
            }

            return View(model);
        }

    }
}
