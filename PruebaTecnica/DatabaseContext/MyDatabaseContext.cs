using Microsoft.EntityFrameworkCore;
using PruebaTecnica.DataModel;

namespace PruebaTecnica.DatabaseContext
{
    public class MyDatabaseContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "SubjectDB");
        }

        public DbSet<SubjectDataModel> Subjects { get; set; }
    }
}
