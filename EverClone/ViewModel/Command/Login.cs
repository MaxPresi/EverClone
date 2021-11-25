using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace EverClone.ViewModel.Command
{
    public class Login : ICommand
    {
        public LoginVM VM { get; set; }

        public event EventHandler CanExecuteChanged;

        public Login(LoginVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
