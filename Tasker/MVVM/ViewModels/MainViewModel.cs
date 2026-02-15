
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasker.MVVM.Models;

namespace Tasker.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class MainViewModel
    {
        public ObservableCollection<Category> Categories { get; set; }
        public ObservableCollection<MyTask> Tasks { get; set; }

        public MainViewModel()
        {
            FillData();
            Tasks.CollectionChanged += Tasks_CollectionChanged;
        }

        private void Tasks_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
           UpdateData();
        }

        private void FillData()
        {
            Categories = new ObservableCollection<Category>
            {
                new Category

            {
                Id = 1, CategoryName = ".NET MAUI  Course", Color = "#CF14DF"
            },
            new Category
            { Id = 2, CategoryName = "Tutorials", Color = "#df6f14" },
            new Category
            { Id = 3, CategoryName = "Shopping", Color = "#14df80" },

        };

            Tasks = new ObservableCollection<MyTask>
                {
                new MyTask { TaskName = "Learn .NET MAUI", CategoryId = 1, Completed = true, TaskColor = "#CF14DF" },
                new MyTask { TaskName = "Build a .NET MAUI App", CategoryId = 1, Completed = true, TaskColor = "#CF14DF" },
                new MyTask { TaskName = "Read .NET MAUI Documentation", CategoryId = 1, Completed = true, TaskColor = "#CF14DF" },
                new MyTask { TaskName = "Watch .NET MAUI Tutorials", CategoryId = 2, Completed = true, TaskColor = "#df6f14" },
                new MyTask { TaskName = "Follow .NET MAUI Blogs", CategoryId = 2, Completed = true, TaskColor = "#df6f14" },
                new MyTask { TaskName = "Buy Groceries", CategoryId = 3, Completed = false, TaskColor = "#14df80" },
                new MyTask { TaskName = "Order Electronics", CategoryId = 3, Completed = true, TaskColor = "#14df80" },
            };
            UpdateData();
        }
        public void UpdateData()
        {
            foreach (var c in Categories)
            {
                var task = from t in Tasks
                           where t.CategoryId == c.Id
                           select t;

                var comleted = from t in Tasks
                               where t.CategoryId == c.Id && t.Completed == true
                               select t;

                var NotCompleted = from t in Tasks
                                   where t.CategoryId == c.Id && t.Completed == false
                                   select t;


                c.PendingTasks = NotCompleted.Count();
                c.PercentTage = (float)comleted.Count() / (float)task.Count();
            }
            foreach (var t in Tasks)
            {
                var catColor = from c in Categories
                               where c.Id == t.CategoryId
                               select c.Color;
                t.TaskColor = catColor.FirstOrDefault();
            }



        }
    }
}
