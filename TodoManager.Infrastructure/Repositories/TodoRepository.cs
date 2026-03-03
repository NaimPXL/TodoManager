using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoManager.Domain.Models;

namespace TodoManager.Infrastructure.Repositories
{
    public class TodoRepository
    {
        private readonly List<TodoItem>? _todos;

        public TodoRepository()
        {
            // TODO: Initialize the list
            _todos = new List<TodoItem>();
        }
        public List<TodoItem> GetAll()
        {
            return new List<TodoItem>(_todos);
        }

        public TodoItem Get(int id)
        {
            return _todos.Find(todo => todo.Id == id);
        }

        public void Add(TodoItem item)
        {
            // TODO: Determine next unique Id
            // TIP: Count + 1
            // TODO: Add to _todos

            item.Id = _todos?.Max(t => t.Id) + 1 ?? 0;
            _todos.Add(item);

        }

        public bool Remove(TodoItem item)
        {
            // TODO: Delete item And return true/false
            return _todos?.Remove(item) ?? false;
        }
    }
}
