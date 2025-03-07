using Data_Layer.Models;

namespace BusinessLayer.IServices
{
    public interface INoteService
    {
        List<Note> GetAllNotes();
        Note? GetNoteById(int id);
        void AddNote(Note note);
        Task UpdateNote(Note note);
        void DeleteNote(int id);
    }
}
