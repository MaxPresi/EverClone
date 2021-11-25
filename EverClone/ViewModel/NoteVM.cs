using EverClone.Model;
using EverClone.ViewModel.Command;
using EverClone.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace EverClone.ViewModel
{
    public class NoteVM : INotifyPropertyChanged
    {
        public ObservableCollection<Notebook> Notebooks { get; set; }
        public ObservableCollection<Note> Notes { get; set; }

        private Notebook selNotebook;

        public Notebook SelNotebook
        {
            get { return selNotebook; }
            set 
            { 
                selNotebook = value;
                OnPropertyChanged("SelNotebook");
                GetNotes();
            }
        }        

        public NewNotebook NewNotebook { get; set; }
        public NewNote NewNote { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public NoteVM()
        {
            NewNotebook = new NewNotebook(this);
            NewNote = new NewNote(this);

            Notebooks = new ObservableCollection<Notebook>();
            Notes = new ObservableCollection<Note>();

            GetNotebooks();
        }

        public void CreateNotebook()
        {
            Notebook newNotebook = new Notebook()
            {
                Name = "Novo Bloco de Notas"
            };

            DBHelper.Insert(newNotebook);

            GetNotebooks();
        }

        public void CreateNote(int notebookId)
        {
            Note newNote = new Note()
            {
                NotebookId = notebookId,
                Created = DateTime.Now,
                Updated = DateTime.Now,
                Title = "Nova Nota"
            };

            DBHelper.Insert(newNote);

            GetNotes();
        }

        public void GetNotebooks()
        {
            var notebooks = DBHelper.Read<Notebook>();

            Notebooks.Clear();

            foreach(var notebook in notebooks)
            {
                Notebooks.Add(notebook);
            }
        }

        public void GetNotes()
        {
            if (SelNotebook != null)
            {
                var notes = DBHelper.Read<Note>().Where(n => n.NotebookId == SelNotebook.Id).ToList();

                Notes.Clear();

                foreach (var note in notes)
                {
                    Notes.Add(note);
                }
            }
        }

        private void OnPropertyChanged(string propetyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propetyName));
        }
    }
}
 