﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace lab8visual.Models
{
    public class SaveLoad
    {
        public static void SaveFile(string path, List<ObservableCollection<Task>> tasks)
        {
            File.WriteAllText(path, "");
            List<string> data = new List<string>();
            foreach (ObservableCollection<Task> taskList in tasks)
            {
                foreach (Task task in taskList)
                {
                    data.Add(task.Status);
                    data.Add(task.Name);
                    data.Add(task.Description);
                    data.Add(task.ImagePath);
                }
                data.Add("");
            }
            File.WriteAllLines(path, data);
        }

        public static List<ObservableCollection<Task>> LoadFile(string path)
        {
            List<ObservableCollection<Task>> tasks = new List<ObservableCollection<Task>>
            {
                new ObservableCollection<Task>(),
                new ObservableCollection<Task>(),
                new ObservableCollection<Task>()
            };

            StreamReader file = new StreamReader(path);

            try
            {
                for (int i = 0; i < tasks.Count(); i++)
                {
                    ObservableCollection<Task> tmp = new ObservableCollection<Task>();
                    while (true)
                    {
                        string status = file.ReadLine();
                        if (status == "")
                            break;
                        string name = file.ReadLine();
                        string description = file.ReadLine();
                        string imagePath = file.ReadLine();

                        tmp.Add(new Task(status, name, description, imagePath));
                    }
                    tasks[i] = tmp;
                }
                file.Close();
                return tasks;
            }
            catch
            {
                file.Close();
                return new List<ObservableCollection<Task>>
                {
                    new ObservableCollection<Task>(),
                    new ObservableCollection<Task>(),
                    new ObservableCollection<Task>()
                };
            }
        }
    }
}
