using System.Linq;
using System.Collections.Generic;
namespace webapi.Models
{
    public class User
    {
        public int userid { get; set; }
        public string name { get; set; }
        public int number { get; set; }
    }

    public interface IUserService
    {
        List<User> GetUsers();
        void AddUsers(User u);
        void UpdateUsers(User u);
        void DeleteUsers(User u);
    }
}
