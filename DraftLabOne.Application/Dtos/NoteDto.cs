using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraftLabOne.Application.Dtos
{
    public record NoteDto(long Id, string Title, string Description, DateTimeOffset CreatedAt);
}
