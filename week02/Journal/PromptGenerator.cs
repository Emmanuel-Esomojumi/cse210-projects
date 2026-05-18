using System;
using System.Collections.Generic;

public class PromptGenerator
{
    private List<string> _prompts;
    private Random _random;

    public PromptGenerator()
    {
        _random = new Random();
        _prompts = new List<string>
        {
            "What was the best part of your day?",
            "Who did you help today?",
            "What did you learn today?",
            "What made you smile today?",
            "What challenge did you overcome today?"
        };
    }

    public string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }
}