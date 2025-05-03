using System.Collections.Generic;
using UnityEngine;

public class LevelUp : MonoBehaviour
{
    private Player player;
    private AgentObject agentObject, baseAgentObject;
    private StatsManager statsManager;
    private List<StatChange> statChanges = new List<StatChange>();
    private float multiplier;

    private void Start()
    {
        player = GetComponent<Player>();
        agentObject = player.agent;
        baseAgentObject = player.agent_base;
        statsManager = new StatsManager(agentObject, baseAgentObject);
        multiplier = baseAgentObject.modifier;
    }

    public void LevelUpAgent()
    {
        // Clear stat changes
        statChanges.Clear();

        // Increase level
        agentObject.level++;

        statsManager.CacheBaseStats();

        // Increase stats
        IncreaseStats();
    }

    void IncreaseStats()
    {
        // Increase all stats
        foreach (var stat in statsManager.baseStats)
        {
            if (statsManager.IsStatUnmodifiable(stat.Key))
                continue;

            float baseValue = stat.Value;
            float newValue = CalculateModifiedStats(baseValue, multiplier, agentObject.level);
            AddStatChange(stat.Key, StatType.Float, newValue);
        }

        ApplyStatChanges();
    }

    private float CalculateModifiedStats(float basevalue, float modifier, int level)
    {
        return (basevalue / modifier) * (level - 1);
    }

    private void ApplyStatChanges()
    {
        statsManager.ApplyStatChanges(statChanges);
    }

    private void AddStatChange(string statName, StatType statType, object value)
    {
        statChanges.Add(new StatChange
        {
            StatName = statName,
            StatType = statType,
            Value = value
        });
    }
}


