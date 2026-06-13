using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    // ================= MAIN LOOP =================
    public void Start()
    {
        int choice = 0;

        while (choice != 6)
        {
            Console.Clear();
            DisplayPlayerInfo();

            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");

            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.Write("Please enter a valid number: ");
            }

            Console.WriteLine();

            switch (choice)
            {
                case 1:
                    CreateGoal();
                    break;
                case 2:
                    ListGoalDetails();
                    break;
                case 3:
                    SaveGoals();
                    break;
                case 4:
                    LoadGoals();
                    break;
                case 5:
                    RecordEvent();
                    break;
                case 6:
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    Pause();
                    break;
            }
        }
    }

    // ================= PLAYER INFO =================
    public void DisplayPlayerInfo()
    {
        int level = (_score / 1000) + 1;
        int nextLevelAt = level * 1000;
        int remaining = nextLevelAt - _score;

        Console.WriteLine($"You have {_score} points.");
        Console.WriteLine($"Level: {level}");
        Console.WriteLine($"Next level in {remaining} points.");
    }

    // ================= CREATE GOAL =================
    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");

        Console.Write("Which type of goal would you like to create? ");

        int type;
        while (!int.TryParse(Console.ReadLine(), out type) || type < 1 || type > 3)
        {
            Console.Write("Please enter 1, 2, or 3: ");
        }

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description? ");
        string description = Console.ReadLine();

        Console.Write("How many points is it worth? ");

        int points;
        while (!int.TryParse(Console.ReadLine(), out points))
        {
            Console.Write("Please enter a valid number: ");
        }

        if (type == 1)
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (type == 2)
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else if (type == 3)
        {
            Console.Write("How many times to complete for bonus? ");

            int target;
            while (!int.TryParse(Console.ReadLine(), out target))
            {
                Console.Write("Please enter a valid number: ");
            }

            Console.Write("What is the bonus? ");

            int bonus;
            while (!int.TryParse(Console.ReadLine(), out bonus))
            {
                Console.Write("Please enter a valid number: ");
            }

            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }
    }

    // ================= LIST =================
    public void ListGoalDetails()
    {
        Console.WriteLine("Your Goals:");

        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals yet.");
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }

        Pause();
    }

    // ================= RECORD EVENT =================
    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals available.");
            Pause();
            return;
        }

        ListGoalNames();

        Console.Write("Which goal did you complete? ");

        int index;
        while (!int.TryParse(Console.ReadLine(), out index) ||
               index < 1 || index > _goals.Count)
        {
            Console.Write("Enter a valid goal number: ");
        }

        Goal goal = _goals[index - 1];

        int earned = goal.RecordEvent();
        _score += earned;

        Console.WriteLine($"You earned {earned} points!");
        Console.WriteLine($"Total score: {_score}");

        Pause();
    }

    // ================= SAVE =================
    public void SaveGoals()
    {
        Console.Write("Enter filename: ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);

            foreach (Goal g in _goals)
            {
                writer.WriteLine(g.GetStringRepresentation());
            }
        }

        Console.WriteLine("Saved successfully.");
        Pause();
    }

    // ================= LOAD =================
    public void LoadGoals()
    {
        Console.Write("Enter filename: ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            Pause();
            return;
        }

        string[] lines = File.ReadAllLines(filename);

        if (!int.TryParse(lines[0], out _score))
        {
            Console.WriteLine("Invalid save file.");
            Pause();
            return;
        }

        _goals.Clear();

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(":");
            string type = parts[0];
            string[] data = parts[1].Split(",");

            if (type == "SimpleGoal")
            {
                _goals.Add(new SimpleGoal(
                    data[0],
                    data[1],
                    int.Parse(data[2]),
                    bool.Parse(data[3])
                ));
            }
            else if (type == "EternalGoal")
            {
                _goals.Add(new EternalGoal(
                    data[0],
                    data[1],
                    int.Parse(data[2])
                ));
            }
            else if (type == "ChecklistGoal")
            {
                _goals.Add(new ChecklistGoal(
                    data[0],
                    data[1],
                    int.Parse(data[2]),
                    int.Parse(data[4]),
                    int.Parse(data[3]),
                    int.Parse(data[5])
                ));
            }
        }

        Console.WriteLine("Loaded successfully.");
        Pause();
    }

    // ================= HELPERS =================
    private void ListGoalNames()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
        }
    }

    private void Pause()
    {
        Console.WriteLine();
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }
}