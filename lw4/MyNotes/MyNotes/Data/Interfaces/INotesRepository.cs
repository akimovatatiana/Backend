using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyNotes.Data.Interfaces;
using MyNotes.Data.Models;

namespace MyNotes.Data.Interfaces
{
    public interface INotesRepository
    {
        IEnumerable<Note> GetNote();
        void AddNote(Note notes);
        void SetPath(string v);
    }
}
