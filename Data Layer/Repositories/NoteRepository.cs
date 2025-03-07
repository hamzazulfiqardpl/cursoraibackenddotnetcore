using Data_Layer.DbContextF;
using Data_Layer.Interface;
using Data_Layer.Models;

namespace Data_Layer.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly NotesDbContext _context;

        public NoteRepository(NotesDbContext context)
        {
            _context = context;
        }

        public List<Note> GetAllNotes() => _context.Notes.ToList();

        public Note? GetNoteById(int id) => _context.Notes.Find(id);

        public void AddNote(Note note)
        {
            _context.Notes.Add(note);
            _context.SaveChanges();
        }

        public async Task UpdateNoteAsync(Note note)
        {
            var existingNote = await _context.Notes.FindAsync(note.Id);
            if (existingNote != null)
            {
                existingNote.Title = note.Title;
                existingNote.Content = note.Content;
                await _context.SaveChangesAsync();
            }
        }

        public void DeleteNote(int id)
        {
            var note = _context.Notes.Find(id);
            if (note != null)
            {
                _context.Notes.Remove(note);
                _context.SaveChanges();
            }
        }

    }
}
