using Mirco.MircosTool.Data.Infrastructure.Repositories.Base;
using Mirco.MircosTool.Models.Entities.todo;
using MircoToolWebApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirco.MircosTool.Data.Infrastructure.Repositories
{
    public class ToDoRepository 
        :EfRepository<DataContext, ToDo, int>,
        ITodoRepository
    {

        public ToDoRepository(DataContext context) : base(context) { }

    }


    public interface ITodoRepository : IRepository<ToDo, int> { }
}
