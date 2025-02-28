using DraftLabOne.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraftLabOne.Infrastructure.Queries.Notes.GetNotesBySelector
{
    public record GetNotesResponse(List<NoteDto> notes);
}
