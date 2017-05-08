using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSBike
{
    public class Repository
    {
        private List<User> lstUsers = new List<User>();

        public Repository()
        {
#if TEST
            this.lstUsers.Add(new User("u1", "男", "110555554433333331", "151444223221", false));
            this.lstUsers.Add(new User("u2", "女", "210555554433333332", "151444223222", false));
            this.lstUsers.Add(new User("a3", "女", "310555554433333333", "151444223223", true));
            this.lstUsers.Add(new User("u4", "男", "410555554433333334", "151444223224", false));


#endif
        }

        public List<User> GetAllUsers()
        {
            return this.lstUsers;
        }

        public void AddUser(User user)
        {
            this.lstUsers.Add(user);
        }

        public void EditUser(int oldId, User user)
        {
            User oldUser = this.lstUsers.First(x => x.Id == oldId);
            oldUser.Name = user.Name;
            oldUser.Gender = user.Gender;
            oldUser.CardNumber = user.CardNumber;
            oldUser.Telephone = user.Telephone;
        }

        public void DeleteUser(User user)
        {
            this.lstUsers.Remove(user);
        }

    }
}
