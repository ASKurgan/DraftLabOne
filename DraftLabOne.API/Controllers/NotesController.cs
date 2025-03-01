using DraftLabOne.API.Note.CreateNote;
using DraftLabOne.Application.Dtos;
using DraftLabOne.Application.Features.NoteFolder.CreateNote;
using DraftLabOne.Infrastructure.DbContexts;
using DraftLabOne.Infrastructure.Queries.Notes.GetNotesBySelector;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GNBSRequest request, 
                                             [FromServices] GNBSQuery handler,
                                             CancellationToken ct)
        {
            var responseResult = await handler.Handle(request, ct);
            if (responseResult.IsFailure)
                return BadRequest(responseResult.Error);

            var result = responseResult.Value;

            return Ok(result);
        }
    }
}
