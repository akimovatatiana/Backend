using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyNotes.Data.Interfaces;
using MyNotes.Data.Repositories;
using MyNotes.Data.Models;
using Newtonsoft.Json;

namespace MyNotes.Controllers
{
    public class NotesController : Controller
    {
        private readonly INotesRepository _notesRepository;
        public NotesController(INotesRepository notesRepository)
        {
            _notesRepository = notesRepository;
            notesRepository.SetPath("NotesStorage\\notes.txt");
        }

        [HttpGet("notes/list")]
        public IActionResult GetList()
        {
            var notes = _notesRepository.GetNote();
            var json = JsonConvert.SerializeObject(notes, Formatting.Indented);
            return Content(json);
        }

        [HttpPost("note/add")]
        public async Task<StatusCodeResult> AddNote()
        {
            Note note = new Note();
            using (StreamReader inputStream = new StreamReader(Request.Body, Encoding.UTF8))
            {
                note.content = await inputStream.ReadToEndAsync();
            }
            _notesRepository.AddNote(note);
            return Ok();
        }
    }
}