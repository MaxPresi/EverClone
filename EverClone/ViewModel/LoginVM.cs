using EverClone.Model;
using EverClone.ViewModel.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace EverClone.ViewModel
{
    public class LoginVM
    {

        private User user;

        public User User
        {
            get { return user; }
            set { user = value; }
        }

        public Register Register { get; set; }
        public Login Login { get; set; }

        public LoginVM()
        {
            Register = new Register(this);
            Login = new Login(this);
        }

    }
}
