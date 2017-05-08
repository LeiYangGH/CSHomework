using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace CSBike
{
    [Serializable]
    public class User
    {
        private static int uniqueId = 0;
        private bool isAdministrator;
        public User(bool isAdministrator)
        {
            this.isAdministrator = isAdministrator;
            this.Id = ++User.uniqueId;
        }


        public User(string name, string gender, string cardNumber, string telephone, bool isAdministrator) : this(isAdministrator)
        {
            this.Name = name;
            this.Gender = gender;
            this.CardNumber = cardNumber;
            this.Telephone = telephone;
        }
        public int Id { get; set; }
        [DisplayName("姓名")]
        public string Name { get; set; }
        [DisplayName("性别")]
        public string Gender { get; set; }
        [DisplayName("身份证号")]
        public string CardNumber { get; set; }
        [DisplayName("手机号")]
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
