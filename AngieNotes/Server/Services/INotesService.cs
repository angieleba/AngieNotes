using AngieNotes.Shared;

namespace AngieNotes.Server.Services
{
    public interface INotesService
    {
        List<Note> GetAll();
        Note GetById(string id);
        void Create(Note note);
        void Update(Note note);
        void Delete(string id);
    }
}
