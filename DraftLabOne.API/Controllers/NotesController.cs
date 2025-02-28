using DraftLabOne.API.Note.CreateNote;
using DraftLabOne.Application.Features.NoteFolder.CreateNote;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DraftLabOne.API.Controllers
{
    [Route ("[controller]")]
    public class NotesController : ApplicationController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromServices] CreateNoteHandler handler,
                                                [FromBody] CreateNoteRequest request, 
                                                           CancellationToken ct)
        {
            var noteCommandResult = CreateNoteMapper.MapToCommand(request.Title, request.Description);
            if (noteCommandResult.IsFailure)
                return BadRequest(noteCommandResult.Error);

            var noteCommand = noteCommandResult.Value;

            var response = await handler.Handle(noteCommand, ct);
            return Ok(response.Value);
        }
    }
}
