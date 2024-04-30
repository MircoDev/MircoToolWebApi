using Mirco.MircosTool.Models.Dto;
using Mirco.MircosTool.Models.Entities.todo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirco.MircosTool.Models.Extensions
{
    public static class TodoToDto
    {
        public static ToDo FromDto(this ToDo todo, TodoDto dto) 
        {

            ToDo new_todo = new ToDo() 
            {
                Description = todo.Description,
                DateExpiration = todo.DateExpiration,
                Priority = todo.Priority,
                IsCompleted = todo.IsCompleted,
            };
            
            return new_todo;

        }

        public static ToDo ToEntity(this TodoDto dto)
        {

            ToDo new_todo = new ToDo()
            {
                Description = dto.Description,
                DateExpiration = dto.DateExpiration,
                Priority = dto.Priority,
                IsCompleted = dto.IsCompleted,
            };

            return new_todo;

        }

    }
}
