public class StatChange
{
    public string StatName { get; set; }
    public StatType StatType { get; set; }
    public object Value { get; set; }
}

public enum StatType
{
    Float,
    Int,
    Bool
}

public class UnmodifiableStat
{
    public string StatName { get; set; }
    public float StatValue { get; set; }

    public UnmodifiableStat(string statName, float statValue)
    {
        StatName = statName;
        StatValue = statValue;
    }
}