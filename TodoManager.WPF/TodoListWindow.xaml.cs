using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TodoManager.Application.Services;
using TodoManager.Domain.Models;

namespace TodoManager.WPF
{
    /// <summary>
    /// Interaction logic for TodoListWindow.xaml
    /// </summary>
    public partial class TodoListWindow : Window
    {
        private readonly TodoService _todoService;

        public TodoListWindow()
        {
            InitializeComponent();

            _todoService = new TodoService();
            RefreshTodos();
        }

        private void RefreshTodos()
        {
            todosListBox.Items.Clear();

            List<TodoItem> todos = _todoService.GetTodos();

            foreach (TodoItem todo in todos)
            {
                todosListBox.Items.Add(todo); // relies on TodoItem.ToString()
            }

            ClearDetails();
        }

        private void ClearDetails()
        {
            titleTextBlock.Text = "";
            dueDateTextBlock.Text = "";
            completedTextBlock.Text = "";
            completedAtTextBlock.Text = "";
            descriptionTextBlock.Text = "";
        }

        private void TodosListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // TODO: retrieve selected todo
            TodoItem todoItem = todosListBox.SelectedItem as TodoItem;

            // TODO: call ClearDetails & return if null
            if (todoItem == null)
            {
                ClearDetails();
                return;
            }
            // TODO: display details in TitleTextBlock, DueDateTextBlock, DescriptionTextBox, CompletedTextBlock, CompletedAtTextBlock
            titleTextBlock.Text = todoItem.Title;
            dueDateTextBlock.Text = todoItem.DueDate.ToString();
            descriptionTextBlock.Text = todoItem.Description ?? "No description";
            completedTextBlock.Text = todoItem.IsCompleted.ToString();
            completedAtTextBlock.Text = todoItem.CompletedAt.ToString() ?? "Not completed";
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddTodoWindow addWindow = new AddTodoWindow();
            addWindow.Owner = this;

            bool? result = addWindow.ShowDialog();
            if (result != true)
            {
                return;
            }

            // TODO: try-catch
            // TODO: _todoService.AddTodo(addWindow.TodoTitle, addWindow.TodoDescription, addWindow.TodoDueDate);
            try
            {
                _todoService.AddTodo(addWindow.TodoTitle, addWindow.TodoDescription, addWindow.TodoDueDate);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                throw;
            }
            // TODO: RefreshTodos();
            RefreshTodos();
        }

        private void CompleteButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
