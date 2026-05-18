using System;

public class Entry
{
    private string _date;
    private string _prompt;
    private string _text;

    // Used when WRITING a new entry
    public Entry(string prompt, string text)
    {
        _date = DateTime.Now.ToShortDateString();
        _prompt = prompt;
        _text = text;
    }

    // Used when LOADING from file
    public Entry(string date, string prompt, string text)
    {
        _date = date;
        _prompt = prompt;
        _text = text;
    }

    public string GetDisplayText()
    {
        return $"{_date}\n{_prompt}\n{_text}\n";
    }

    public string GetSaveText()
    {
        return $"{_date}|{_prompt}|{_text}";
    }
}