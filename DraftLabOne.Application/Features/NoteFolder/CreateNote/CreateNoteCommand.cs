using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraftLabOne.Application.Features.NoteFolder.CreateNote
{
    public record CreateNoteCommand(string Title, string Description);
}
