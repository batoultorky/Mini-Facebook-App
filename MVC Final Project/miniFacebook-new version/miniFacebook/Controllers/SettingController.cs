using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using miniFacebook.Models;
using miniFacebook.view_Models;

namespace miniFacebook.Controllers
{
    public class SettingController : Controller
    {
        private readonly UserManager<Applicationuser> _userManager;
        private readonly SignInManager<Applicationuser> _signInManager;
        public SettingController(UserManager<Applicationuser> _userManager, SignInManager<Applicationuser> _signInManager)
        {
            this._userManager = _userManager;
            this._signInManager = _signInManager;
        }
        [HttpGet]
        public IActionResult changePassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> changePassword(changePasswordModel vm)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                // var user = await _userManager.FindByEmailAsync()
                if (user == null)
                {
                    return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
                }
                var changePasswordResult = await _userManager.ChangePasswordAsync(user, vm.oldPassword, vm.newPassword);
                if (!changePasswordResult.Succeeded)
                {
                    foreach (var error in changePasswordResult.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View(vm);
                }

                await _signInManager.RefreshSignInAsync(user);
                return RedirectToAction("Home", "FacebookHome");
            }

            return View(vm);


        }
    }
}

