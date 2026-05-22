using System;

public class Fraction
{
    // 1. Private attributes (ENCAPSULATION)
    private int _top;
    private int _bottom;

    // 2. No-argument constructor (defaults to 1/1)
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    // 3. One-argument constructor (top/1)
    public Fraction(int top)
    {
        _top = top;
        _bottom = 1;
    }

    // 4. Two-argument constructor (top/bottom)
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    // 5. Getters and Setters
    public int GetTop()
    {
        return _top;
    }

    public void SetTop(int top)
    {
        _top = top;
    }

    public int GetBottom()
    {
        return _bottom;
    }

    public void SetBottom(int bottom)
    {
        _bottom = bottom;
    }

    // 6. Fraction string representation
    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }

    // 7. Decimal representation
    public double GetDecimalValue()
    {
        return (double)_top / _bottom;
    }
}