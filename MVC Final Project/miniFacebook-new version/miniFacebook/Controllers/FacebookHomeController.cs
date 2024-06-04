using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using miniFacebook.Models;
using miniFacebook.view_Models;

namespace miniFacebook.Controllers
{
    public class FacebookHomeController : Controller
    {
        private readonly UserManager<Applicationuser> _userManager;
        private readonly SignInManager<Applicationuser> _signInManager;

        facebookDbcontext db;
        HomeModel alllData = new HomeModel();
        public FacebookHomeController(facebookDbcontext context, UserManager<Applicationuser> _userrManeger, SignInManager<Applicationuser> signInManager)
        {
            db = context;
            this._userManager = _userrManeger;
            _signInManager = signInManager;

        }


        public async Task<IActionResult> Home()
        {

            Applicationuser loggedInUser = await _userManager.GetUserAsync(User);
            alllData.allUser = db.users.ToList();
            alllData.allPost = db.posts.OrderByDescending(p => p.date).ToList();

            alllData.currentUser = loggedInUser;



            return View(alllData);
        }

        [HttpPost]
        public async Task<IActionResult> addpost(string postValue)
        {
            if (string.IsNullOrEmpty(postValue))
            {
                // Handle empty post content
                return RedirectToAction("Home");
            }

            var loggedInUser = await _userManager.GetUserAsync(User);
            Post post = new Post();
            post.body = postValue;
            post.date = DateTime.Now;
            post.userId = loggedInUser.Id;
            db.posts.Add(post);
            db.SaveChanges();
            return RedirectToAction("Home");
        }


        [HttpGet]
        public IActionResult GetFilteredUsers(string value)
        {
            List<Applicationuser> filteredUsers = db.Users
                .Where(u => u.UserName.Contains(value))
                .ToList();
            //db.users = filteredUsers;

            return Json(filteredUsers);
        }
    }
       
    
}
