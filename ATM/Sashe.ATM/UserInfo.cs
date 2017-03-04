using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sashe.ATM
{
    public class UserInfo
    {
        private int _uid;

        public int Uid
        {
            get { return _uid; }
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

        public UserInfo(int uid, string firstName, string lastName, string address)
        {
            _uid = uid;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
        }
    }
}
