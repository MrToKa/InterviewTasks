namespace To_DoListApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var toDoList = new List<ToDoList>();

            while (true)
            {
                PrintMenu();

                int input = CheckIntInput("Enter your choice:");

                switch (input)
                {
                    case 1:
                        AddTask(toDoList);
                        Console.WriteLine($"Task successfully added to the list!");
                        break;
                    case 2:
                        ListTasks(toDoList);
                        break;
                    case 3:
                        MarkTaskAsDone(toDoList);
                        break;
                    case 4:
                        RemoveTask(toDoList);
                        break;
                    case 5:
                        FilterByCompletionStatus(toDoList);
                        break;
                    case 6:
                        Console.WriteLine("Thank you for using To-Do List App!");
                        return;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            }

        }

        private static void AddTask(List<ToDoList> toDoList)
        {
            var title = CheckStringInput("Enter the title of the task:");
            if (toDoList.Any(x => x.Title == title))
            {
                Console.WriteLine("Task with the same title already exists");
                return;
            }
            var description = CheckStringInput("Enter the description of the task:");
            var dueDate = CheckDateTimeInput("Enter the due date of the task (dd/mm/yyyy):");
            var isDone = CheckBoolInput("Enter the completion status of the task (true/false):");

            var task = new ToDoList(title, description, dueDate, isDone);
            toDoList.Add(task);
        }

        private static void ListTasks(List<ToDoList> toDoList)
        {
            if (toDoList.Count == 0)
            {
                Console.WriteLine("No tasks found");
                return;
            }

            Console.WriteLine($"There are {toDoList.Count} tasks in the list:");
            foreach (var task in toDoList)
            {
                Console.WriteLine(task);
            }
        }

        private static void MarkTaskAsDone(List<ToDoList> toDoList)
        {
            var title = CheckStringInput("Enter the title of the task you want to mark as done:");

            var task = toDoList.FirstOrDefault(x => x.Title == title);

            if (task == null)
            {
                Console.WriteLine("Task not found");
                return;
            }

            if (task.IsDone)
            {
                Console.WriteLine("Task already marked as done");
                return;
            }

            task.IsDone = true;
            Console.WriteLine("Task successfully marked as done");
        }

        private static void RemoveTask(List<ToDoList> toDoList)
        {
            var title = CheckStringInput("Enter the title of the task you want to remove:");

            var task = toDoList.FirstOrDefault(x => x.Title == title);

            if (task == null)
            {
                Console.WriteLine("Task not found");
                return;
            }

            toDoList.Remove(task);
            Console.WriteLine("Task successfully removed");
        }

        private static void FilterByCompletionStatus(List<ToDoList> toDoList)
        {
            var isDone = CheckBoolInput("Enter the completion status of the task (true/false):");

            var filteredTasks = toDoList.Where(x => x.IsDone == isDone);

            if (!filteredTasks.Any())
            {
                Console.WriteLine("No tasks found");
                return;
            }

            Console.WriteLine($"There are {filteredTasks.Count()} tasks with completion status {isDone}:");

            foreach (var task in filteredTasks)
            {
                Console.WriteLine(task);
            }
        }

        private static string CheckStringInput(string message)
        {
            Console.WriteLine(message);
            string input = Console.ReadLine();
            while (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Invalid input");
                input = Console.ReadLine();
            }

            return input;
        }

        private static DateTime CheckDateTimeInput(string message)
        {
            bool isDateTime = DateTime.TryParse(CheckStringInput(message), out DateTime result);
            while (true)
            {
                if (isDateTime)
                {
                    return result;
                }

                Console.WriteLine("Invalid input");
                isDateTime = DateTime.TryParse(CheckStringInput(message), out result);
            }
        }

        private static bool CheckBoolInput(string message)
        {
            bool isBool = bool.TryParse(CheckStringInput(message), out bool result);
            while (true)
            {
                if (isBool)
                {
                    return result;
                }

                Console.WriteLine("Invalid input");
                isBool = bool.TryParse(CheckStringInput(message), out result);
            }
        }

        private static int CheckIntInput(string message)
        {
            string input = CheckStringInput(message);
            int output;
            while (!int.TryParse(input, out output))
            {
                Console.WriteLine("Invalid input");
                input = CheckStringInput(message);
            }
            return output;
        }

        static void PrintMenu()
        {
            Console.WriteLine("To-Do List App Menu:");
            Console.WriteLine("1. Add a new task");
            Console.WriteLine("2. List all tasks");
            Console.WriteLine("3. Mark a task as done");
            Console.WriteLine("4. Remove a task");
            Console.WriteLine("5. Filter by Completion Status");
            Console.WriteLine("6. Exit");
        }
    }

    internal class ToDoList
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsDone { get; set; }

        public ToDoList(string title, string description, DateTime dueDate, bool isDone)
        {
            Title = title;
            Description = description;
            DueDate = dueDate;
            IsDone = isDone;
        }

        public override string ToString()
        {
            return $"Title: {Title}, Description: {Description}, Due Date: {DueDate}, Is Done: {IsDone}";
        }

    }
}