using DraftLabOne.Domain.Common;
using DraftLabOne.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraftLabOne.Application.Features.NoteFolder.CreateNote
{
    public interface INoteRepository
    {
        Task Add(Note note, CancellationToken ct);
        Task<Result<Note>> GetById(long id, CancellationToken ct);
        Task<Result<Note>> GetByTittle(string tittle, CancellationToken ct);
        Task<IReadOnlyList<Note>> GetAll(CancellationToken ct);
    }
}
