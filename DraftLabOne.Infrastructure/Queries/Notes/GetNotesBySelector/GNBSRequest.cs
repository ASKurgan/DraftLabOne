using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraftLabOne.Infrastructure.Queries.Notes.GetNotesBySelector
{
    // GNBS - Get Notes By Selector
    public record GNBSRequest(string? Search, string? SortItem, string? SortOrder);
}
