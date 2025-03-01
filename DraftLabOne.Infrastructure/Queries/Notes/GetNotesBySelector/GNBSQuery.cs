using DraftLabOne.Application.Dtos;
using DraftLabOne.Domain.Common;
using DraftLabOne.Domain.Entities;
using DraftLabOne.Infrastructure.DbContexts;
using DraftLabOne.Infrastructure.ReadModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DraftLabOne.Infrastructure.Queries.Notes.GetNotesBySelector
{
    //GNBS -  Get Notes By Selector
    public class GNBSQuery
    {
        private readonly NotesReadDbContext _context;

        public GNBSQuery(NotesReadDbContext context)
        {
            _context = context;
        }

        public async Task<Result<GetNotesResponse>> Handle(GNBSRequest request,
                                                            CancellationToken ct)
        {
            var notesQuery = _context.NoteReads
                .Where(n => string.IsNullOrWhiteSpace(request.Search) ||
                            n.Title.ToLower().Contains(request.Search.ToLower()));
                       

            Expression<Func<NoteReadModel, object>> selectorKey = request.SortItem?.ToLower() switch
            {
                "date" => note => note.CreatedAt,
                "title" => note => note.Title,
                _ => note => note.Id
            };

            notesQuery = request.SortOrder == "desc"
                ? notesQuery.OrderByDescending(selectorKey)
                : notesQuery.OrderBy(selectorKey);

            var noteDtos = await notesQuery
                .Select(n => new NoteDto(n.Id, n.Title, n.Description, n.CreatedAt))
                .ToListAsync(ct);

           // return noteDtos;
            return new GetNotesResponse(noteDtos);
        }
    }
}
