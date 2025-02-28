using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraftLabOne.Infrastructure.ReadModels
{
    public class NoteReadModel
    {
        public long Id { get; init; }
        public string Tittle { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public  DateTimeOffset CreateAd { get; init; }
    }
}
