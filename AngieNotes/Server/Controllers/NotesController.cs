using AngieNotes.Server.Services;
using AngieNotes.Shared;
using Microsoft.AspNetCore.Mvc;

namespace AngieNotes.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly ILogger<NotesController> _logger;
        private readonly INotesService NotesService;

        public NotesController(ILogger<NotesController> logger, INotesService notesService)
        {
            _logger = logger;
            this.NotesService = notesService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Note>> Get()
        {
            var notes = NotesService.GetAll();
            return Ok(notes);
        }


        [HttpGet]
        [Route("{id}")]
        public ActionResult<Note> Get(string id)
        {
            var note = NotesService.GetById(id);
            return Ok(note);
        }


        [HttpPost]
        public ActionResult<Note> Create(Note note)
        {
            NotesService.Create(note);
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult<Note> Update(Note note)
        {
            NotesService.Update(note);
            return Ok();
        }


        [HttpDelete]
        [Route("{id}")]
        public ActionResult<Note> Delete(string id)
        {
            NotesService.Delete(id);
            return Ok();
        }
    }
}