// Exceeds requirements: data is stored in a dedicated Data folder
// to separate persistence from application logic.

using System;

class Program
{
    static void Main()
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        bool running = true;

        while (running)
        {
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine(prompt);
                    Console.Write("> ");
                    string response = Console.ReadLine();

                    Entry entry = new Entry(prompt, response);
                    journal.AddEntry(entry);
                    break;

                case "2":
                    journal.DisplayEntries();
                    break;

                case "3":
                    journal.LoadFromFile("Data/journal.txt");
                    break;

                case "4":
                    journal.SaveToFile("Data/journal.txt");
                    break;

                case "5":
                    running = false;
                    break;
            }
        }
    }
}