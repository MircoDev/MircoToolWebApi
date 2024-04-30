using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mirco.MircosTool.Data.Infrastructure.Context.Base;
using Mirco.MircosTool.Models.Entities.todo;
using MircoToolWebApi.Entities;

namespace MircoToolWebApi.Data
{
    public class DataContext : EfContext<DataContext>
    {
        public DataContext(
            DbContextOptions<DataContext> options,
            ILogger<DataContext> logger) 
            : base(options,logger)
        {
            
        }

        public DbSet<ToDo> ToDos { get; set; }


    }
}
