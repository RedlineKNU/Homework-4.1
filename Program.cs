using System;
using System.Collections.Generic;

public abstract class Worker
{
    public string Name { get; set; }
    public string Position { get; set; }
    public string WorkDay { get; set; }

    public Worker(string name)
    {
        Name = name;
        WorkDay = "";
    }

    public void Call()
    {
        WorkDay += $"{Name} made a call.\n";
    }

    public void WriteCode()
    {
        WorkDay += $"{Name} wrote code.\n";
    }

    public void Relax()
    {
        WorkDay += $"{Name} is relaxing.\n";
    }

    public abstract void FillWorkDay();
}

public class Developer : Worker
{
    public Developer(string name) : base(name)
    {
        Position = "Developer";
    }

    public override void FillWorkDay()
    {
        WriteCode();
        Call();
        Relax();
        WriteCode();
    }
}

public class Manager : Worker
{
    private Random random = new Random();

    public Manager(string name) : base(name)
    {
        Position = "Manager";
    }

    public override void FillWorkDay()
    {
        int calls = random.Next(1, 11);
        for (int i = 0; i < calls; i++)
        {
            Call();
        }
        Relax();
        calls = random.Next(1, 6);
        for (int i = 0; i < calls; i++)
        {
            Call();
        }
    }
}

public class Team
{
    private List<Worker> workers;

    public Team()
    {
        workers = new List<Worker>();
    }

    public void AddWorker(Worker worker)
    {
        workers.Add(worker);
    }

    public void DisplayTeamInfo()
    {
        foreach (var worker in workers)
        {
            Console.WriteLine(worker.Name);
        }
    }

    public void DisplayDetailedInfo()
    {
        foreach (var worker in workers)
        {
            Console.WriteLine($"{worker.Name} - {worker.Position} - {worker.WorkDay}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Team team = new Team();
        Console.Write("Enter the name of the Developer: ");
        string devName = Console.ReadLine();
        Developer dev1 = new Developer(devName);
        dev1.FillWorkDay();

        Console.Write("Enter the name of the Manager: ");
        string manName = Console.ReadLine();
        Manager man1 = new Manager(manName);
        man1.FillWorkDay();

        team.AddWorker(dev1);
        team.AddWorker(man1);

        team.DisplayTeamInfo();
        team.DisplayDetailedInfo();
    }
}