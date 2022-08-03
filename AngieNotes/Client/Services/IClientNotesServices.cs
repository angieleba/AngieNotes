using AngieNotes.Client.Pages.Notes;
using AngieNotes.Shared;

namespace AngieNotes.Client.Services
{
    public interface IClientNotesServices
    {
        Task<List<Note>> GetAll();
        Task<Note> GetById(string id);
        Task<bool> Create(Note note);
        Task<bool> Update(Note note);
        Task<bool> Delete(string id);
    }
}
