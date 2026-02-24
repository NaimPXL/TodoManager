using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoManager.Domain.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Title { get; }
        public string? Description { get; }
        public DateTime DueDate { get; }
        public bool IsCompleted { get; private set; }
        public DateTime? CompletedAt { get; private set; }

        public TodoItem(string title, string? description, DateTime dueDate)
        {
            if (String.IsNullOrEmpty(title))
            {
                throw new ArgumentException("Value cannot be Null or Empty!");
            }
            Title = title;
            Description = description;
            DueDate = dueDate;
            IsCompleted = false;
            CompletedAt = null;
        }

        public void MarkAsCompleted()
        {
            if (!IsCompleted)
            {
                // TODO: zet IsCompleted op true
                IsCompleted = true;
                // TODO: zet CompletedAt op DateTime.Now
                CompletedAt = DateTime.Now;
            }
        }

        public override string ToString()
        {
            string status = IsCompleted ? "[Done]" : "[Open]";
            return $"{status} {Title} (due {DueDate:dd/MM/yyyy})";
        }


    }
}
