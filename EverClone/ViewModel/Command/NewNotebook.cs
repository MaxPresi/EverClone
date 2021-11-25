using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace EverClone.ViewModel.Command
{
    public class NewNotebook : ICommand
    {
        public NoteVM VM { get; set; }

        public event EventHandler CanExecuteChanged;

        public NewNotebook(NoteVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            VM.CreateNotebook();
        }
    }
}

