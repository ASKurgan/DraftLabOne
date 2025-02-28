using DraftLabOne.Application.Features.NoteFolder.CreateNote;
using DraftLabOne.Domain.Common;

namespace DraftLabOne.API.Note.CreateNote
{
    public class CreateNoteMapper
    {
        public static Result<CreateNoteCommand> MapToCommand(string title, string description)
        {
            return new CreateNoteCommand(title, description);
        }
    }
}
