using MyNotes.Data.Interfaces;
using MyNotes.Data.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using Newtonsoft.Json.Linq;

namespace MyNotes.Data.Repositories
{
    public class NotesRepository : INotesRepository
    {
        private static string notesPath;
        public void SetPath(string filePath)
        {
            notesPath = filePath;
        }
        public IEnumerable<Note> GetNote()
        {
            List<Note> notes = new List<Note> { };
            string line;
            using (StreamReader notesFile = new StreamReader(notesPath, Encoding.UTF8))
            {
                while ((line = notesFile.ReadLine()) != null)
                {
                    notes.Add(new Note { content = line });
                }
            }
            return notes;
        }
        public void AddNote(Note note)
        {
            using (StreamWriter notesStorage = new StreamWriter(notesPath, true))
            {
                notesStorage.WriteLine(note.content);
            }
        }
    }
}
