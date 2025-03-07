using BusinessLayer.IServices;
using Data_Layer.Models;
using Microsoft.AspNetCore.Mvc;

namespace NotesAppBkend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NotesController(INoteService noteService)
        {
            _noteService = noteService;
        }

        // Get all notes
        [HttpGet]
        public IActionResult GetAllNotes() => Ok(_noteService.GetAllNotes());

        // Get note by ID
        [HttpGet("{id}")]
        public IActionResult GetNoteById(int id)
        {
            var note = _noteService.GetNoteById(id);
            return note != null ? Ok(note) : NotFound("Note not found");
        }

        // Create a new note
        [HttpPost]
        public IActionResult CreateNote([FromBody] Note note)
        {
            if (string.IsNullOrWhiteSpace(note.Title) || string.IsNullOrWhiteSpace(note.Content))
                return BadRequest("Title and Content are required");

            _noteService.AddNote(note);
            return CreatedAtAction(nameof(GetNoteById), new { id = note.Id }, note);
        }

        // Update an existing note
        [HttpPut("{id}")]
        public IActionResult UpdateNote(int id, [FromBody] Note note)
        {
            var existingNote = _noteService.GetNoteById(id);
            if (existingNote == null) return NotFound("Note not found");

            note.Id = id;
            _noteService.UpdateNote(note);
            return NoContent();
        }

        // Delete a note
        [HttpDelete("{id}")]
        public IActionResult DeleteNote(int id)
        {
            var note = _noteService.GetNoteById(id);
            if (note == null) return NotFound("Note not found");

            _noteService.DeleteNote(id);
            return NoContent();
        }
    }
}
