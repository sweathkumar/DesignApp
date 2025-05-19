using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignApp.Model
{
    public class LoginModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Passcode { get; set; }
        public string Passcodeconfirm { get; set; }
        public bool PageOne { get; set; }
        public bool PageTwo { get; set; }
        public bool PageThree { get; set; }
    }
}
