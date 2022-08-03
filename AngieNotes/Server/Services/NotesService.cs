using AngieNotes.Shared;

namespace AngieNotes.Server.Services
{
    public class NotesService : INotesService
    {
        public List<Note> Notes { get; set; } = new List<Note>() { new Note()
        {
            Title = "This is a title for note",
            Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
            Priority = Priority.Medium
        } };
        
        /// <summary>
        /// Returns all notes
        /// </summary>
        /// <returns></returns>
        public List<Note> GetAll()
        {
            return Notes;
        }

        /// <summary>
        /// Returns note by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Note GetById(string id)
        {
            //Throws error if Id does not exist
            return Notes.First(x => x.Id == id);
        }

        /// <summary>
        /// Creates a new Note
        /// </summary>
        /// <param name="note"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public void Create(Note note)
        {
            try
            {
                if (note != null)
                    Notes.Add(note);
                else
                    throw new Exception("Note cannot be null!");
            }
            catch (Exception e)
            {
                throw;
            }
        }

        /// <summary>
        /// Updates a note
        /// </summary>
        /// <param name="note"></param>
        /// <exception cref="Exception"></exception>
        public void Update(Note note)
        {
            try
            {
                var oldNote = GetById(note.Id);
                if (oldNote != null)
                {
                    Notes.Remove(oldNote);
                }
                Notes.Add(note);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        /// <summary>
        /// Deletes a note by Id
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="Exception"></exception>
        public void Delete(string id)
        {
            try
            {
                var note = GetById(id);
                if (note != null)
                    Notes.Remove(note);
               
            } catch(Exception e)
            {
                throw;
            }
            
        }
    }
}
