using TaskTrackerCLI.Services;

var service = new TaskService();
if (args.Length == 0)
{
    Console.WriteLine("Commands:");
    Console.WriteLine("add \"task\"");
    Console.WriteLine("list");
    Console.WriteLine("delete ID");
    Console.WriteLine("done ID");
    return;
}
string command = args[0];

switch (command)
{
    case "add":
        service.AddTask(args[1]);
        break;

    case "list":
        service.ListTasks();
        break;

    case "delete":
        service.DeleteTask(int.Parse(args[1]));
        break;

    case "done":
        service.MarkDone(int.Parse(args[1]));
        break;

    default:
        Console.WriteLine("Unknown command");
        break;
}

