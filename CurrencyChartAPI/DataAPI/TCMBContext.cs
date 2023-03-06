using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace DataAPI
{
    public class TCMBContext : DbContext
    {
        public DbSet<ResponseDataKur> ResponseDataKurs { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-QQB8DP7; Database=TCMB; Integrated Security=true;");
        }
    }
}
