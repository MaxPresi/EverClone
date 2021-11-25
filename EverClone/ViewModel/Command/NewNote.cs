using EverClone.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace EverClone.ViewModel.Command
{
    public class NewNote : ICommand
    {
        public NoteVM VM { get; set; }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public NewNote(NoteVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            Notebook selNotebook = parameter as Notebook;
            if (selNotebook != null) return true;
            return false;
        }

        public void Execute(object parameter)
        {
            Notebook selNotebook = parameter as Notebook;
            VM.CreateNote(selNotebook.Id);
        }
    }
}
