using Data_Layer.Models;

namespace Data_Layer.Interface
{
    public interface INoteRepository
    {
        List<Note> GetAllNotes();
        Note? GetNoteById(int id);
        void AddNote(Note note);
        Task UpdateNoteAsync(Note note);
        void DeleteNote(int id);
    }
}
