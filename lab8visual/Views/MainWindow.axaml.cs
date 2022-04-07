using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Collections.ObjectModel;
using lab8visual.Models;
using lab8visual.ViewModels;
using Avalonia.Media.Imaging;

namespace lab8visual.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.FindControl<MenuItem>("NewBtn").Click += delegate
            {

                var context = this.DataContext as MainWindowViewModel;
                context.TodoTasks.Clear();
                context.DoingTasks.Clear();
                context.DoneTasks.Clear();
            };

            this.FindControl<MenuItem>("LoadBtn").Click += async delegate
            {
                var taskPath = new OpenFileDialog()
                {
                    Title = "Search File",
                    Filters = null
                }.ShowAsync((Window)this.VisualRoot);

                string[]? filePath = await taskPath;

                if (filePath != null)
                {
                    var context = this.DataContext as MainWindowViewModel;
                    context.LoadFile(string.Join(@"\", filePath));
                }
            };

            this.FindControl<MenuItem>("SaveBtn").Click += async delegate
            {
                var taskPath = new OpenFileDialog()
                {
                    Title = "Search File",
                    Filters = null
                }.ShowAsync((Window)this.VisualRoot);

                string[]? filePath = await taskPath;

                if (filePath != null)
                {
                    var context = this.DataContext as MainWindowViewModel;
                    context.SaveFile(string.Join(@"\", filePath));
                }
            };

            this.FindControl<MenuItem>("ExitBtn").Click += delegate
            {
                Close();
            };
        }

        public async void AddImage(object sender, RoutedEventArgs e)
        {
            Task task = (Task)((Button)sender).DataContext;
            var taskPath = new OpenFileDialog()
            {
                Title = "Search File",
                Filters = null
            }.ShowAsync((Window)this.VisualRoot);

            string[]? filePath = await taskPath;

            if (filePath != null)
            {
                task.ImagePath = filePath[0];
                task.Image = new Bitmap(filePath[0]);
            }
        }

        private void DeleteTask(object sender, RoutedEventArgs e)
        {
            var context = this.DataContext as MainWindowViewModel;
            Task task = (Task)((Button)sender).DataContext;
            if (context != null)
            {
                switch (task.Status)
                {
                    case "ToDo":
                        context.TodoTasks.Remove(task);
                        break;
                    case "Doing":
                        context.DoingTasks.Remove(task);
                        break;
                    case "Done":
                        context.DoneTasks.Remove(task);
                        break;
                }
            }
        }

        private async void AboutPage(object control, RoutedEventArgs arg)
        {
            await new About().ShowDialog((Window)this.VisualRoot);
        }
    }
}
