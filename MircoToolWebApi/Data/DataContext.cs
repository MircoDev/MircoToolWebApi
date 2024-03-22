using Microsoft.EntityFrameworkCore;
using MircoToolWebApi.Entities;

namespace MircoToolWebApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<ToDo> ToDos { get; set; }


    }
}
