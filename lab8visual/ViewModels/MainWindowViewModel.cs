using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using ReactiveUI;
using System.Reactive;
using lab8visual.Models;

namespace lab8visual.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        ObservableCollection<Task> todoTasks;
        ObservableCollection<Task> doingTasks;
        ObservableCollection<Task> doneTasks;

        public MainWindowViewModel()
        {
            todoTasks = new ObservableCollection<Task>();
            doingTasks = new ObservableCollection<Task>();
            doneTasks = new ObservableCollection<Task>();
        }

        public ObservableCollection<Task> TodoTasks
        {
            get => todoTasks;
            set
            {
                this.RaiseAndSetIfChanged(ref todoTasks, value);
            }
        }

        public ObservableCollection<Task> DoingTasks
        {
            get => doingTasks;
            set
            {
                this.RaiseAndSetIfChanged(ref doingTasks, value);
            }
        }

        public ObservableCollection<Task> DoneTasks
        {
            get => doneTasks;
            set
            {
                this.RaiseAndSetIfChanged(ref doneTasks, value);
            }
        }

        public void AddTask(string taskType)
        {
            switch (taskType)
            {
                case "ToDo":
                    TodoTasks.Add(new Task("ToDo"));
                    break;
                case "Doing":
                    DoingTasks.Add(new Task("Doing"));
                    break;
                case "Done":
                    DoneTasks.Add(new Task("Done"));
                    break;
            }
        }

        public void SaveFile(string path)
        {
            List<ObservableCollection<Task>> tasks = new List<ObservableCollection<Task>> { TodoTasks, DoingTasks, DoneTasks };
            SaveLoad.SaveFile(path, tasks);
        }

        public void LoadFile(string path)
        {
            List<ObservableCollection<Task>> tasks = SaveLoad.LoadFile(path);
            TodoTasks = tasks[0];
            DoingTasks = tasks[1];
            DoneTasks = tasks[2];
        }
    }
}
