namespace IMDB.Infrastructure.Database
{
    public partial class IMDBDbContext : IMDB.Core.Applications.Common.Interfaces.IApplicationDbContext
    {
        public void SetAutoTransactions(bool enable)
        {
            Database.AutoTransactionsEnabled = enable;
        }
    }
}
