
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;


public class dictionary {

    public Dictionary<string, float> stats = new Dictionary<string, float>();

    public dictionary(){
        foreach (FieldInfo field in typeof(PlayableAgent).GetFields()){
            if (field.FieldType == typeof(float)){
                stats[field.Name] = 0;
            }
        }
    }

    public float getStat(string name){
        return stats[name];
    }

    public void setStat(string name, float value){
        stats[name] = value;
    }

    public void addStat(string name, float value){
        if (stats.ContainsKey(name)){
            stats[name] += value;
        } else {
            stats[name] = value;
        }
    }

    public void addStat(Dictionary<string, float> stats){
        //filter out the stats that are not in the dictionary and values that are 0
        var filteredStats = new Dictionary<string, float>();
        foreach (KeyValuePair<string, float> stat in stats){
            if (stat.Value != 0){
                filteredStats[stat.Key] = stat.Value;
            }
        }
        //add the stats
        foreach (KeyValuePair<string, float> stat in filteredStats){
            addStat(stat.Key, stat.Value);
        }
    }

    public void removeStat(string name, float value){
        if (stats.ContainsKey(name)){
            stats[name] -= value;
        } else {
            stats[name] = value;
        }
    }

    public void removeStat(Dictionary<string, float> stats){
        foreach (KeyValuePair<string, float> stat in stats){
            removeStat(stat.Key, stat.Value);
        }
    }

    public void multiplyStat(string name, float value){
        if (stats.ContainsKey(name)){
            stats[name] *= value;
        } else {
            stats[name] = value;
        }
    }

    public void divideStat(string name, float value){
        if (stats.ContainsKey(name)){
            stats[name] /= value;
        } else {
            stats[name] = value;
        }
    }

    public void setplayableagentBaseStats(PlayableAgent agent){
        setStat("damage_Physical", agent.damage_Physical);
        setStat("damage_Magical", agent.damage_Magical);
        setStat("maxHitPoint", agent.maxHitPoint);
        setStat("hitPointCurrent", agent.maxHitPoint);
        setStat("regen_hitPoint", agent.regen_hitPoint);
        setStat("maxManaPoint", agent.maxManaPoint);
        setStat("manaPointCurrent", agent.maxManaPoint);
        setStat("regen_manaPoint", agent.regen_manaPoint);
        setStat("maxWildPoint", agent.maxWildPoint);
        setStat("regen_wildPoint", agent.regen_wildPoint);
        setStat("maxEnergyPoint", agent.maxEnergyPoint);
        setStat("regen_energyPoint", agent.regen_energyPoint);
        setStat("armor_Physical", agent.armor_Physical);
        setStat("armor_Magical", agent.armor_Magical);
        setStat("speed_Movement", agent.speed_Movement);
        setStat("speed_Attack", agent.speed_Attack);
        setStat("penetration_Physical", agent.penetration_Physical);
        setStat("penetration_Magical", agent.penetration_Magical);
        setStat("criticalchance_Physical", agent.criticalchance_Physical);
        setStat("criticaldamage_Physical", agent.criticaldamage_Physical);
        setStat("criticalcahnce_Magical", agent.criticalchance_Magical);
        setStat("criticaldamage_Magical", agent.criticaldamage_Magical);
        setStat("rate_Block", agent.rate_Block);
        setStat("rate_Parry", agent.rate_Parry);
        setStat("rate_Dodge", agent.rate_Dodge);
        setStat("accuracy", agent.accuracy);
        setStat("tenacity", agent.tenacity);
        setStat("penetration_Tenacity", agent.penetration_Tenacity);
        setStat("speed_Jump", agent.speed_Jump);
        setStat("speed_Fly", agent.speed_Fly);
        setStat("leech", agent.leech);
    }

    public void setnotplayableagentStats(notPlayableAgent agent)
    {
        setStat("damage_Physical", agent.damage_Physical);
        setStat("damage_Magical", agent.damage_Magical);
        setStat("maxHitPoint", agent.maxHitPoint);
        setStat("regen_hitPoint", agent.regen_hitPoint);
        setStat("maxManaPoint", agent.maxManaPoint);
        setStat("regen_manaPoint", agent.regen_manaPoint);
        setStat("maxWildPoint", agent.maxWildPoint);
        setStat("regen_wildPoint", agent.regen_wildPoint);
        setStat("maxEnergyPoint", agent.maxEnergyPoint);
        setStat("regen_energyPoint", agent.regen_energyPoint);
        setStat("armor_Physical", agent.armor_Physical);
        setStat("armor_Magical", agent.armor_Magical);
        setStat("speed_Movement", agent.speed_Movement);
        setStat("speed_Attack", agent.speed_Attack);
        setStat("penetration_Physical", agent.penetration_Physical);
        setStat("penetration_Magical", agent.penetration_Magical);
        setStat("criticalchance_Physical", agent.criticalchance_Physical);
        setStat("criticaldamage_Physical", agent.criticaldamage_Physical);
        setStat("criticalcahnce_Magical", agent.criticalchance_Magical);
        setStat("criticaldamage_Magical", agent.criticaldamage_Magical);
        setStat("rate_Block", agent.rate_Block);
        setStat("rate_Parry", agent.rate_Parry);
        setStat("rate_Dodge", agent.rate_Dodge);
        setStat("accuracy", agent.accuracy);
        setStat("tenacity", agent.tenacity);
        setStat("penetration_Tenacity", agent.penetration_Tenacity);
        setStat("speed_Jump", agent.speed_Jump);
        setStat("speed_Fly", agent.speed_Fly);
        setStat("leech", agent.leech);
    }
    public void setitemBaseStats(Item item)
    {
        setStat("damage_Physical", item.damage_Physical);
        setStat("damage_Magical", item.damage_Magical);
        setStat("maxHitPoint", item.maxHitPoint);
        setStat("hitPointCurrent", item.maxHitPoint);
        setStat("regen_hitPoint", item.regen_hitPoint);
        setStat("maxManaPoint", item.maxManaPoint);
        setStat("manaPointCurrent", item.maxManaPoint);
        setStat("regen_manaPoint", item.regen_manaPoint);
        setStat("maxWildPoint", item.maxWildPoint);
        setStat("regen_wildPoint", item.regen_wildPoint);
        setStat("maxEnergyPoint", item.maxEnergyPoint);
        setStat("regen_energyPoint", item.regen_energyPoint);
        setStat("armor_Physical", item.armor_Physical);
        setStat("armor_Magical", item.armor_Magical);
        setStat("speed_Movement", item.speed_Movement);
        setStat("speed_Attack", item.speed_Attack);
        setStat("penetration_Physical", item.penetration_Physical);
        setStat("penetration_Magical", item.penetration_Magical);
        setStat("criticalchance_Physical", item.criticalchance_Physical);
        setStat("criticaldamage_Physical", item.criticaldamage_Physical);
        setStat("criticalcahnce_Magical", item.criticalcahnce_Magical);
        setStat("criticaldamage_Magical", item.criticaldamage_Magical);
        setStat("rate_Block", item.rate_Block);
        setStat("rate_Parry", item.rate_Parry);
        setStat("rate_Dodge", item.rate_Dodge);
        setStat("accuracy", item.accuracy);
        setStat("tenacity", item.tenacity);
        setStat("penetration_Tenacity", item.penetration_Tenacity);
        setStat("speed_Jump", item.speed_Jump);
        setStat("speed_Fly", item.speed_Fly);
        setStat("leech", item.leech);
    }

    public Dictionary<string, float> getFilteredStats(){
        //filter the stats if value = 0
        Dictionary<string, float> filteredStats = new Dictionary<string, float>();
        foreach (KeyValuePair<string, float> stat in stats){
            if (stat.Value != 0){
                filteredStats.Add(stat.Key, stat.Value);
            }
        }
        return filteredStats;
    }

    public void setFilteredStats(PlayableAgent agent, Dictionary<string, float> filteredStats){
        filteredStats = getFilteredStats();
        foreach (KeyValuePair<string, float> stat in filteredStats){
            FieldInfo field = agent.GetType().GetField(stat.Key);
            field.SetValue(agent, stat.Value);
        }
    }

    public void clearStats(){
        stats.Clear();
    }

    public void printStats(){
        foreach (KeyValuePair<string, float> stat in stats){
            Debug.Log(stat.Key + " : " + stat.Value);
        }
    }

    public void printFilteredStats(){
        foreach (KeyValuePair<string, float> stat in getFilteredStats()){
            Debug.Log(stat.Key + " : " + stat.Value);
        }
    }
}