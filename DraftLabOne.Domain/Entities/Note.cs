using DraftLabOne.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraftLabOne.Domain.Entities
{
    public class Note: Entity
    {
        private Note() {}
        private Note(string title, string description)
        {
            Title = title;
            Description = description;
            CreatedAt = DateTimeOffset.UtcNow;
        }

      
        public string Title { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public DateTimeOffset CreatedAt { get; init; }

        public static Result<Note> Create(string tittle, string description)
        {
            return new Note(tittle, description);
        }
    }
}
