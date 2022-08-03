using AngieNotes.Client.Pages.Notes;
using AngieNotes.Shared;
using Newtonsoft.Json;
using System.Text;

namespace AngieNotes.Client.Services
{
    public class ClientNotesService : IClientNotesServices
    {
        private readonly HttpClient httpClient;

        public ClientNotesService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        /// <summary>
        /// Returns all elements
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<Note>> GetAll()
        {
            var res = await httpClient.GetAsync("api/notes");
            if (res.IsSuccessStatusCode)
            {
                var responseString = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Note>>(responseString);
            }
            else
            {
                //Show error message 
                throw new Exception("Something went wrong with retrieval of notes");
            }
        }

        /// <summary>
        /// Returns an element by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Note> GetById(string id)
        {
            var res = await httpClient.GetAsync($"api/notes/{id}");
            if (res.IsSuccessStatusCode)
            {
                var responseString = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Note>(responseString);
            }
            else
            {
                //Show error message 
                throw new Exception("Something went wrong with retrieval of notes");
            }
        }

        /// <summary>
        /// Creates a new note
        /// </summary>
        /// <param name="note"></param>
        /// <returns></returns>
        public async Task<bool> Create(Note note)
        {
            var content = JsonConvert.SerializeObject(note);
            var stringContent = new StringContent(content, UnicodeEncoding.UTF8, "application/json");

            var res = await httpClient.PostAsync("api/notes", stringContent);
            return res.IsSuccessStatusCode;
        }

        /// <summary>
        /// Updates a new note
        /// </summary>
        /// <param name="note"></param>
        /// <returns></returns>
        public async Task<bool> Update(Note note)
        {
            var content = JsonConvert.SerializeObject(note);
            var stringContent = new StringContent(content, UnicodeEncoding.UTF8, "application/json");

            var res = await httpClient.PutAsync($"api/notes/{note.Id}", stringContent);
            return res.IsSuccessStatusCode;
        }

        /// <summary>
        /// Deletes a note
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> Delete(string id)
        {
            var res = await httpClient.DeleteAsync($"api/notes/{id}");
            return res.IsSuccessStatusCode;
        }
    }
}
