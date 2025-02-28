using DraftLabOne.Application.Interfaces.DataAccess;
using DraftLabOne.Domain.Common;
using DraftLabOne.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraftLabOne.Application.Features.NoteFolder.CreateNote
{
    public class CreateNoteHandler
    {
        private readonly INoteRepository _noteRepository;
        private readonly ITransaction _transaction;

        public CreateNoteHandler(INoteRepository noteRepository, ITransaction transaction)
        {
            _noteRepository = noteRepository;
            _transaction = transaction;
        }

        public async Task<Result<long>> Handle(CreateNoteCommand noteCommand, CancellationToken ct)
        {
            var noteResult = Note.Create(noteCommand.Title, noteCommand.Description);
            if (noteResult.IsFailure)
            {
                return Errors.General.Iternal(noteResult.Error.Message);
            }

            var note = noteResult.Value;

            await _noteRepository.Add(note, ct);
            await _transaction.SaveChangesAsync(ct);

            return note.Id;
        }
    }
}
