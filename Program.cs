List<string> ToDoList = [];

void ShowAllToDo()
{
    if (ToDoList.Count == 0)
    {
        Console.WriteLine("\nToDo list is empty\n");
        return;
    }
    Console.Clear();
    ushort count = 0;
    foreach (string todoStr in ToDoList)
    {
        count++;
        Console.WriteLine("[" + count.ToString() + "] " + todoStr);
    }
}

void AddToDo()
{
    while (true)
    {
        string? inStr = Console.ReadLine();
        if (inStr == null)
        {
            Console.Clear();
            Console.WriteLine("\nInvalid input!\n");
            continue;
        }
        bool isDuplicate = false;
        foreach (string todoStr in ToDoList)
        {
            if (todoStr.Equals(inStr, StringComparison.OrdinalIgnoreCase))
            {
                isDuplicate = true;
                break;
            }
        }

        if (isDuplicate)
        {
            Console.Clear();
            Console.WriteLine("\nToDo must be unique!\nEnter ToDo again:\n");
            continue;
        }

        ToDoList.Add(inStr);
        return;
    }
}

void RemoveToDo()
{
    while (true)
    {
        if (ToDoList.Count == 0)
        {
            Console.WriteLine("\nToDo list is empty\n");
            return;
        }
        ShowAllToDo();
        Console.WriteLine("\nSelect the ToDo to remove:\n");
        string? inStr = Console.ReadLine();
        if (inStr == null)
        {
            Console.Clear();
            Console.WriteLine("\nInvalid input!\n");
            continue;
        }
        if (int.TryParse(inStr, out int index))
        {
            if ((index <= 0) && (index > ToDoList.Count))
            {
                Console.Clear();
                Console.WriteLine("\nInput exceeds the number of ToDo items!\n");
                continue;
            }
            index--;
            ToDoList.RemoveAt(index);
            return;
        }
        else
        {
            Console.Clear();
            Console.WriteLine("\nInvalid input!\n");
            continue;
        }
    }
}

Console.WriteLine("Hello!\n");
while (true)
{
    Console.WriteLine("What do you want to do?\n\n" + "[S]ee all TODOs\n" + "[A]dd a TODO\n" + "[R]emove a TODO\n" + "[E]xit\n");
    string? inStr = Console.ReadLine();
    if (inStr == null)
    {
        Console.Clear();
        Console.WriteLine("\nInvalid input!\n");
        continue;
    }

    if (inStr.Equals("S", StringComparison.OrdinalIgnoreCase))
    {
        ShowAllToDo();
    }
    else if (inStr.Equals("A", StringComparison.OrdinalIgnoreCase))
    {
        AddToDo();
    }
    else if (inStr.Equals("R", StringComparison.OrdinalIgnoreCase))
    {
        RemoveToDo();
    }
    else if (inStr.Equals("E", StringComparison.OrdinalIgnoreCase))
    {
        Environment.Exit(0);
    }
    else
    {
        Console.Clear();
        Console.WriteLine("\nInvalid input!\n");
    }
}