using System.ComponentModel.DataAnnotations.Schema;

namespace miniFacebook.Models
{
    public class Post
    {
        public int id { get; set; }
        public string body { get; set; }
        public DateTime date { get; set; }
        [ForeignKey("user")]
        public string userId { get; set; }
        public  virtual Applicationuser user { get; set; }
    }
}
