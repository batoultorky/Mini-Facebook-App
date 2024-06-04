using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using miniFacebook.Models;
using miniFacebook.view_Models;
using System.Runtime.Intrinsics.Arm;

namespace miniFacebook.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<Applicationuser> _userManager;
        private readonly SignInManager<Applicationuser> _signInManager;

        facebookDbcontext db;
        HomeModel navBarData = new HomeModel();

        public ProfileController(facebookDbcontext context , UserManager<Applicationuser> _userrManeger, SignInManager<Applicationuser> signInManager)
        {
            db = context;
            this._userManager = _userrManeger;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> profile ()
        {
            

            DateTime now= DateTime.Now;
            Applicationuser loggedInUser = await _userManager.GetUserAsync(User);
            navBarData.allUser = db.users.ToList();
            navBarData.currentUser = loggedInUser;
            

            List<Post> posts = db.posts.Where(p => p.userId == loggedInUser.Id).OrderByDescending(p => p.date).ToList();

            ViewBag.Posts = posts;
            ViewBag.Now = now;
            ViewBag.user=db.users.ToList();

            return View(navBarData);
        }
        [HttpPost]
        public async Task<IActionResult> SingleFileUpload(IFormFile SingleFile)
        {
            var loggedInUser = await _userManager.GetUserAsync(User);
            if (ModelState.IsValid)
            {
                if (SingleFile != null && SingleFile.Length > 0)
                {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", SingleFile.FileName);
                    if (!System.IO.File.Exists(filePath)) 
                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await SingleFile.CopyToAsync(stream);
                    }
                     
                    loggedInUser.photo = $"/images/{SingleFile.FileName}";
                    db.users.Update(loggedInUser);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("profile");
        }
        [HttpGet]
        public async Task<IActionResult> updateinfo()
        {
            var loggedInUser = await _userManager.GetUserAsync(User);
            return View(loggedInUser);
        }
        [HttpPost]
        public async Task<IActionResult> updateinfo(UserInfoModel userInfo)
        {
            var loggedInUser = await _userManager.GetUserAsync(User);
            if (ModelState.IsValid)
            {
                loggedInUser.fullname=userInfo.fullname;
                loggedInUser.gender = userInfo.gender;
                loggedInUser.birthDate = userInfo.birthDate;
                loggedInUser.bio= userInfo.bio;
                db.users.Update(loggedInUser);
                db.SaveChanges();
                return RedirectToAction("profile");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> addpost(string postValue)
        {
            var loggedInUser = await _userManager.GetUserAsync(User);
            Post post = new Post();
            post.body = postValue;
            post.date = DateTime.Now;
            post.userId = loggedInUser.Id;
            db.posts.Add(post);
            db.SaveChanges();
            return RedirectToAction("profile");
        }

        public async Task< IActionResult> getprofilebyid(string id)
        {

            
            DateTime now = DateTime.Now;
            Applicationuser loggedInUser = db.users.Where(u => u.Id == id).FirstOrDefault();
            Applicationuser loginuser = await _userManager.GetUserAsync(User);
            List<Post> posts = db.posts.Where(p => p.userId == loggedInUser.Id).OrderByDescending(p => p.date).ToList();
            navBarData.allUser = db.users.ToList();
            navBarData.currentUser = loginuser;
            navBarData.allPost = posts;

            
            ViewBag.DisplayUser = loggedInUser;
            ViewBag.Now = now;
            return View(navBarData);
        }
    }
}
