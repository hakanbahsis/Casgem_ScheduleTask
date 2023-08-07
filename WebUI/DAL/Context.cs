using Microsoft.EntityFrameworkCore;

namespace WebUI.DAL
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server =DESKTOP-PK98KLS; Database = CasgemCalenderDb; Trusted_Connection = True;TrustServerCertificate=True;");
        }

        public DbSet<Event> Events { get; set; }


    }
}
