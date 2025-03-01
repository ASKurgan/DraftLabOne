using DraftLabOne.Infrastructure.ReadModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraftLabOne.Infrastructure.Configurations.Read
{
    public class NoteReadConfiguration : IEntityTypeConfiguration<NoteReadModel>
    {
        public void Configure(EntityTypeBuilder<NoteReadModel> builder)
        {
            throw new NotImplementedException();
        }
    }
}
