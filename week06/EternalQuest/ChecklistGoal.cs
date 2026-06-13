public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    // Used when creating a NEW goal
    public ChecklistGoal(
        string shortName,
        string description,
        int points,
        int bonus,
        int target)
        : base(shortName, description, points)
    {
        _bonus = bonus;
        _target = target;
        _amountCompleted = 0;
    }

    // Used when LOADING from file
    public ChecklistGoal(
        string shortName,
        string description,
        int points,
        int bonus,
        int target,
        int amountCompleted)
        : base(shortName, description, points)
    {
        _bonus = bonus;
        _target = target;
        _amountCompleted = amountCompleted;
    }

    public override int RecordEvent()
    {
        if (_amountCompleted >= _target)
        {
            return 0;
        }

        _amountCompleted++;

        // Give bonus ONLY when completing final requirement
        if (_amountCompleted == _target)
        {
            return GetPoints() + _bonus;
        }

        return GetPoints();
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        return $"{status} {GetShortName()} ({GetDescription()}) -- {_amountCompleted}/{_target} completed";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{GetShortName()},{GetDescription()},{GetPoints()},{_bonus},{_target},{_amountCompleted}";
    }
}