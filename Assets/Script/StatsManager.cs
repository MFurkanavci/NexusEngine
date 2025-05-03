using UnityEngine;
using System.Collections.Generic;

public class StatsManager
{
    public AgentObject agent;
    public AgentObject baseAgentObject;
    public Dictionary<string, float> baseStats;
    public Dictionary<string, float> statModifiers;

    public HashSet<string> UnmodifiableStatNames { get; } = new HashSet<string>
    {
        "modifier",
        "damage_range",
        "experience",
        "speed_Movement",
        "speed_Jump",
        "speed_Fly"
    };


    public List<UnmodifiableStat> UnmodifiableStats
    {
        get
        {
            var unmodifiableStats = new List<UnmodifiableStat>();

            foreach (var statName in UnmodifiableStatNames)
            {
                unmodifiableStats.Add(new UnmodifiableStat(statName, GetStat(statName)));
            }

            return unmodifiableStats;
        }
    }

    public bool IsStatUnmodifiable(string statName)
    {
        return UnmodifiableStatNames.Contains(statName);
    }


    public StatsManager(AgentObject agent, AgentObject agent_base)
    {
        this.agent = agent;
        baseAgentObject = agent_base;
        baseStats = new Dictionary<string, float>();
        statModifiers = new Dictionary<string, float>();
        CacheBaseStats();
    }

    public void CacheBaseStats()
    {
        baseStats.Clear();

        var fields = baseAgentObject.GetType().GetFields();
        foreach (var field in fields)
        {
            if (field.FieldType == typeof(float))
                baseStats[field.Name] = (float)field.GetValue(baseAgentObject);
        }
    }

    public float GetStat(string statName)
    {
        if (baseStats.TryGetValue(statName, out float baseValue))
        {
            float modifiedValue = baseValue;

            if (statModifiers.TryGetValue(statName, out float modifier))
                modifiedValue += modifier;

            return modifiedValue;
        }

        Debug.LogWarning($"Stat '{statName}' not found in AgentObject.");
        return 0f;
    }

    public void ApplyStatChanges(List<StatChange> statChanges)
    {
        foreach (var statChange in statChanges)
        {
            switch (statChange.StatType)
            {
                case StatType.Float:
                    ModifyStat(statChange.StatName, (float)statChange.Value);
                    break;

                case StatType.Int:
                    ModifyStat(statChange.StatName, (float)(int)statChange.Value);
                    break;

                case StatType.Bool:
                    ModifyStat(statChange.StatName, (bool)statChange.Value ? 1f : 0f);
                    break;
            }
        }
    }

    public void ModifyStat(string statName, float modifier)
    {
        if (baseStats.ContainsKey(statName))
        {
            if (statModifiers.ContainsKey(statName))
                statModifiers[statName] += modifier;
            else
                statModifiers[statName] = modifier;
        }
        else
        {
            Debug.LogWarning($"Stat '{statName}' not found in AgentObject.");
        }

        AddStatsToAgent();
        ResetAllStats();
    }

    public void ResetStat(string statName)
    {
        if (statModifiers.ContainsKey(statName))
            statModifiers[statName] = 0f;
        else
            Debug.LogWarning($"Stat '{statName}' not found in AgentObject.");
    }

    public void ResetAllStats()
    {
        statModifiers.Clear();
    }

    public void AddStatsToAgent()
    {
        var fields = agent.GetType().GetFields();

        foreach (var field in fields)
        {
            if (field.FieldType == typeof(float))
            {
                if (statModifiers.TryGetValue(field.Name, out float modifier))
                    field.SetValue(agent, modifier + baseStats[field.Name]);
            }
        }
    }
}
