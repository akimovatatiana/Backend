using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyNotes.Data.Models;
using MyNotes.Data.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace MyNotesTests
{
    [TestClass]
    public class AddNoteTests
    {
        private string pathAddNote = @"../../../TestStorage/AddNote.txt";
        public void AddNote(Note note)
        {
            NotesRepository notesRepository = new NotesRepository();
            notesRepository.SetPath(pathAddNote);
            notesRepository.AddNote(note);
        }
        [TestMethod]
        public void AddNote_WithOneNote_ShouldAddNoteToFile()
        {
            string line = "new note";
            Note note = new Note { content = line };
            AddNote(note);
            string expectedLine = "new note";
            Assert.AreEqual(expectedLine, note.content);
        }
    }
    [TestClass]
    public class GetNoteTests
    {
        private string pathGetNote = @"../../../TestStorage/GetNotes.txt";
        public IEnumerable<Note> GetNote()
        {
            NotesRepository notesRepository = new NotesRepository();
            notesRepository.SetPath(pathGetNote);
            return notesRepository.GetNote();
        }
        [TestMethod]
        public void GetNote_ShouldGetNoteListFromFile()
        {
            var notes = GetNote();
            string[] notesList = notes.Select(note => note.content).ToArray();
            string[] expectedList = { "some note", "это заметка" };
            CollectionAssert.AreEqual(expectedList, notesList);
        }
    }
}
