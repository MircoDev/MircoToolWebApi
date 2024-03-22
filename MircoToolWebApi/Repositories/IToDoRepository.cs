using MircoToolWebApi.Entities;

namespace MircoToolWebApi.Repositories
{
    public interface IToDoRepository
    {
        List<ToDo> GetAllToDos(); 
        OperationResult AddTodo(ToDo toDo);

        OperationResult UpdateTodo(ToDo toDo);

        OperationResult DeleteTodo(ToDo toDo);


    }
}
