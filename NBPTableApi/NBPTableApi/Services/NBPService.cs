using NBPTableApi.AppDbContext;

namespace NBPTableApi.Services
{
    public class NBPService : INBPService
    {
        AppDbContextSqlite dbContext;
        public NBPService(AppDbContextSqlite dbContext) 
        {
            this.dbContext = new AppDbContextSqlite();

        }
        public string GetNBPTable()
        {
            //dbContext.
            return "";


        }
    }
}
