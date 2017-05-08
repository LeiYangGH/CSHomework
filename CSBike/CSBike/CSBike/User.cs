using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSBike
{
    public class User
    {
        private static int uniqueId = 0;
        private bool isAdministrator;
        public User()
        {
            this.Id = ++User.uniqueId;
        }
        public User(string name, string gender, string cardNumber, string telephone, bool isAdministrator) : this()
        {
            this.Name = name;
            this.Gender = gender;
            this.CardNumber = cardNumber;
            this.Telephone = telephone;
            this.isAdministrator = isAdministrator;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string CardNumber { get; set; }
        public string Telephone { get; set; }
        public string Password { get; set; }
        public bool IsAdministrator
        {
            get
            {
                return this.isAdministrator;
            }
        }
    }
}
