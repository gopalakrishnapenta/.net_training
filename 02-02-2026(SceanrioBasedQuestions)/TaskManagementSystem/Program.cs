using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskManagementSystem
{
    // TaskItem class
    class TaskItem
    {
        public int TaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; } // High / Medium / Low
        public string Status { get; set; }   // ToDo / InProgress / Completed
        public DateTime DueDate { get; set; }
        public string AssignedTo { get; set; }
    }

    // Project class
    class Project
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectManager { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<TaskItem> Tasks { get; set; }

        public Project()
        {
            Tasks = new List<TaskItem>();
        }
    }

    // TaskManager class
    class TaskManager
    {
        private List<Project> projects = new List<Project>();
        private int projectCounter = 1;
        private int taskCounter = 1;

        // Create project
        public void CreateProject(string name, string manager,
                                  DateTime start, DateTime end)
        {
            Project project = new Project
            {
                ProjectId = projectCounter++,
                ProjectName = name,
                ProjectManager = manager,
                StartDate = start,
                EndDate = end
            };

            projects.Add(project);
            Console.WriteLine("Project created successfully");
        }

        // Add task to project
        public void AddTask(int projectId, string title, string description,
                            string priority, DateTime dueDate, string assignee)
        {
            Project project = projects.FirstOrDefault(p => p.ProjectId == projectId);
            if (project == null)
                return;

            TaskItem task = new TaskItem
            {
                TaskId = taskCounter++,
                Title = title,
                Description = description,
                Priority = priority,
                Status = "ToDo",
                DueDate = dueDate,
                AssignedTo = assignee
            };

            project.Tasks.Add(task);
            Console.WriteLine("Task added successfully");
        }

        // Group tasks by priority
        public Dictionary<string, List<TaskItem>> GroupTasksByPriority()
        {
            return projects
                .SelectMany(p => p.Tasks)
                .GroupBy(t => t.Priority)
                .ToDictionary(g => g.Key, g => g.ToList());
        }

        // Get overdue tasks
        public List<TaskItem> GetOverdueTasks()
        {
            DateTime today = DateTime.Today;

            return projects
                .SelectMany(p => p.Tasks)
                .Where(t => t.DueDate < today && t.Status != "Completed")
                .ToList();
        }

        // Get tasks by assignee
        public List<TaskItem> GetTasksByAssignee(string assigneeName)
        {
            return projects
                .SelectMany(p => p.Tasks)
                .Where(t => t.AssignedTo == assigneeName)
                .ToList();
        }
    }

    // Program class
    class Program
    {
        static void Main()
        {
            TaskManager manager = new TaskManager();

            // Create project
            manager.CreateProject("Website Development", "Arjun",
                                  DateTime.Now.AddDays(-5),
                                  DateTime.Now.AddDays(30));

            // Add tasks
            manager.AddTask(1, "Design UI", "Create homepage UI",
                            "High", DateTime.Now.AddDays(3), "Ravi");

            manager.AddTask(1, "API Integration", "Connect backend APIs",
                            "Medium", DateTime.Now.AddDays(-1), "Anita");

            manager.AddTask(1, "Testing", "Perform unit testing",
                            "Low", DateTime.Now.AddDays(5), "Ravi");

            // Group tasks by priority
            Console.WriteLine("\nTasks Grouped By Priority:");
            var grouped = manager.GroupTasksByPriority();
            foreach (var group in grouped)
            {
                Console.WriteLine(group.Key);
                foreach (var task in group.Value)
                    Console.WriteLine(task.Title);
            }

            // Overdue tasks
            Console.WriteLine("\nOverdue Tasks:");
            var overdue = manager.GetOverdueTasks();
            foreach (var task in overdue)
                Console.WriteLine(task.Title + " - Assigned to " + task.AssignedTo);

            // Tasks by assignee
            Console.WriteLine("\nTasks Assigned to Ravi:");
            var raviTasks = manager.GetTasksByAssignee("Ravi");
            foreach (var task in raviTasks)
                Console.WriteLine(task.Title + " (" + task.Status + ")");
        }
    }
}
