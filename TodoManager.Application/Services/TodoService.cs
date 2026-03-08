using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoManager.Domain.Models;
using TodoManager.Infrastructure.Repositories;

namespace TodoManager.Application.Services
{
    public class TodoService
    {
        private readonly TodoRepository _repository;

        public TodoService()
        {
            // TODO: maak de repository aan
            _repository = new TodoRepository();
        }

        public List<TodoItem> GetTodos()
        {
            // TODO: return alle todos via repository
            return _repository.GetAll();
        }

        public void AddTodo(string title, string? description, DateTime dueDate)
        {
            TodoItem? duplicate = _repository.GetAll().Find(todo => todo.Title.Equals(title.Trim(), StringComparison.OrdinalIgnoreCase));
            // throw InvalidOperationException
            if (duplicate!=null)
            {
                throw new InvalidOperationException($"A todo with the title '{title}' already exists.");
            }
            TodoItem todoItem = new TodoItem(title, description, dueDate);
            _repository.Add(todoItem);
        }
        public void CompleteTodo(TodoItem todo)
        {
            // TODO: zoek het item in de repository (TIP: `Get(todo.id)`)
            // TODO: roep `MarkAsCompleted()` aan
            _repository.Get(todo.Id).MarkAsCompleted();
        }

        public void DeleteTodo(TodoItem todo)
        {
            if (todo.DueDate.Date < DateTime.Today)
            {
                throw new InvalidOperationException("...");
            }

            if (todo.IsCompleted)
            {
                throw new InvalidOperationException("...");
            }

            _repository.Remove(todo);
        }


    }
}
