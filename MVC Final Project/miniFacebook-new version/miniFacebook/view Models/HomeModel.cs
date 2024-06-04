using miniFacebook.Models;

namespace miniFacebook.view_Models
{
    public class HomeModel
    {
         public List<Applicationuser> allUser { set; get; }
        public List<Post> allPost { set; get; }
        public Applicationuser currentUser { set; get; }
    }
}
