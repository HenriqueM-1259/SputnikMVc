using Microsoft.EntityFrameworkCore;

namespace SputnikMVc.Context
{
    public class MySQLContext:DbContext 
    {
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }

    }
}
