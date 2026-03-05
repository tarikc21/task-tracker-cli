using System.Text.Json;
using TaskTrackerCLI.Models;

namespace TaskTrackerCLI.Services
{
    public class TaskService
    {
        private List<TaskItem> tasks = new();
        private string filePath = "tasks.json";

        public TaskService()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                tasks = JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();
            }
        }
        private void Save()
        {
            string json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }
        public void AddTask(string about)
        {
            int tempid = tasks.Count == 0 ? 1 : tasks.Max(x => x.Id) + 1;

            TaskItem task = new TaskItem
            {
                Id = tempid,
                About = about,
                Status = Status.todo,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            tasks.Add(task);
            Save();
            Console.WriteLine($"Task added with id {tempid}");
        }
        public void ListTasks()
        {
            if (tasks.Count() == 0)
            {
                Console.WriteLine("List is empty!");
                return;
            }
            foreach (var task in tasks)
            {
                Console.WriteLine($"{task.Id} | {task.About} | {task.Status}");
            }
        }
        public void DeleteTask(int id)
        {
            var task = tasks.FirstOrDefault(x => x.Id == id);
            if (task == null)
            {
                Console.WriteLine("Task not found!");
                return;
            }
            tasks.Remove(task);
            Save();
            Console.WriteLine($"Task with id {task.Id} deleted!");
        }
        public void MarkDone(int id)
        {
            var task = tasks.FirstOrDefault(x => x.Id == id);
            if (task == null)
            {
                Console.WriteLine("Task not found!");
                return;
            }
            task.Status = Status.done;
            task.UpdatedAt = DateTime.Now;
            Save();
            Console.WriteLine($"Task with id {task.Id} marked done!");
        }
    }
}
