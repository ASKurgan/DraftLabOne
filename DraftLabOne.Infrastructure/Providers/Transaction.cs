using DraftLabOne.Application.Interfaces.DataAccess;
using DraftLabOne.Infrastructure.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraftLabOne.Infrastructure.Providers
{
    public class Transaction : ITransaction
    {
        private readonly NotesWriteDbContext _dbContext;

        public Transaction(NotesWriteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
