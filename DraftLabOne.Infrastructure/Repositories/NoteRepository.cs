using DraftLabOne.Application.Features.NoteFolder.CreateNote;
using DraftLabOne.Domain.Common;
using DraftLabOne.Domain.Entities;
using DraftLabOne.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraftLabOne.Infrastructure.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly NotesWriteDbContext _db;

        public NoteRepository(NotesWriteDbContext db)
        {
            _db = db;
        }


        public async Task Add(Note note, CancellationToken ct)
        {
            await _db.Notes.AddAsync(note, ct);
           // await _db.SaveChangesAsync(ct);

        }

        public Task<IReadOnlyList<Note>> GetAll(CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<Note>> GetById(long id, CancellationToken ct)
        {
            var note = await _db.Notes
                             .FirstOrDefaultAsync(n => n.Id == id, ct);

            if (note == null)
                 return Errors.General.NotFound(id);

            return note;
            
        }

        public async Task<Result<Note>> GetByTittle(string tittle, CancellationToken ct)
        {
            var note = await _db.Notes
                             .FirstOrDefaultAsync(n => n.Title == tittle, ct);

            if (note == null)
                return Errors.General.NotFound();

            return note;
        }
    }
}
