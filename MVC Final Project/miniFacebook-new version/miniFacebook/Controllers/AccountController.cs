using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using miniFacebook.Models;
using miniFacebook.view_Models;


namespace miniFacebook.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<Applicationuser> _userManager;
        private readonly SignInManager<Applicationuser> _signInManager;
        public AccountController(UserManager<Applicationuser> _userrManeger, SignInManager<Applicationuser> signInManager)
        {
            this._userManager = _userrManeger;
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterationModel vm)
        {
            if (ModelState.IsValid)
            {


                Applicationuser userModel = new Applicationuser();
                userModel.Email = vm.Email;
                userModel.fullname = vm.fullname;
                userModel.UserName = vm.UserName;
                userModel.gender = vm.gender;
                userModel.PasswordHash = vm.Password;
                userModel.photo = "/images/default.png";
                IdentityResult result = await _userManager.CreateAsync(userModel, userModel.PasswordHash);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(userModel, "Member");
                    await _signInManager.SignInAsync(userModel, isPersistent: true);

                    return RedirectToAction("Home", "FacebookHome");


                }
                else
                {
                    foreach (var e in result.Errors)
                    {
                        ModelState.AddModelError("Password", e.Description);
                    }

                }
            }
            return View(vm);
        }
        //[HttpGet]
        //public IActionResult Login()
        //{
        //    return View();
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Login(LoginModel vm)
        {
            if (ModelState.IsValid)
            {
                Applicationuser userModel = await _userManager.FindByEmailAsync(vm.Email);
                if (userModel != null)
                {
                  var result=  await _userManager.CheckPasswordAsync(userModel,vm.Password);
                    if(result==true)
                    {
                        await _signInManager.SignInAsync(userModel,isPersistent:true);
                        return RedirectToAction("Home", "FacebookHome");

                    }
                    else
                    {
                        ModelState.AddModelError("", "Email or password is wrong");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Email or password is wrong");
                }
            }

            return View(vm);

        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Register", "Account");
        }
    }
}
