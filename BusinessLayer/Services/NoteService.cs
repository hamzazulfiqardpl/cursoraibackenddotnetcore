using BusinessLayer.IServices;
using Data_Layer.Interface;
using Data_Layer.Models;

namespace BusinessLayer.Services
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepository;

        public NoteService(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public List<Note> GetAllNotes() => _noteRepository.GetAllNotes();

        public Note? GetNoteById(int id) => _noteRepository.GetNoteById(id);

        public void AddNote(Note note) => _noteRepository.AddNote(note);

        public async Task UpdateNote(Note note) =>  await _noteRepository.UpdateNoteAsync(note);

        public void DeleteNote(int id) => _noteRepository.DeleteNote(id);

    }
}
