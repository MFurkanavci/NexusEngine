//this is a dictionary for stats
//it is used to store the stats of the player

using UnityEngine;
using System.Collections;
using System.Collections.Generic;


//create a dictionary for stats

public class dictionary {

    public Dictionary<string, float> stats = new Dictionary<string, float>();

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
        foreach (KeyValuePair<string, float> stat in stats){
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

    public void setagentBaseStats(PlayableAgent agent){
        setStat("damage_Physical", agent.damage_Physical);
        setStat("damage_Magical", agent.damage_Magical);
        setStat("hitPoint", agent.hitPoint);
        setStat("regen_hitPoint", agent.regen_hitPoint);
        setStat("manaPoint", agent.manaPoint);
        setStat("regen_manaPoint", agent.regen_manaPoint);
        setStat("wildPoint", agent.wildPoint);
        setStat("regen_wildPoint", agent.regen_wildPoint);
        setStat("energyPoint", agent.energyPoint);
        setStat("regen_energyPoint", agent.regen_energyPoint);
        setStat("armor_Physical", agent.armor_Physical);
        setStat("armor_Magical", agent.armor_Magical);
        setStat("speed_Movement", agent.speed_Movement);
        setStat("speed_Attack", agent.speed_Attack);
        setStat("penetration_Physical", agent.penetration_Physical);
        setStat("penetration_Magical", agent.penetration_Magical);
        setStat("criticalchance_Physical", agent.criticalchance_Physical);
        setStat("criticaldamage_Physical", agent.criticaldamage_Physical);
        setStat("criticalcahnce_Magical", agent.criticalcahnce_Magical);
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
        setStat("hitPoint", item.hitPoint);
        setStat("regen_hitPoint", item.regen_hitPoint);
        setStat("manaPoint", item.manaPoint);
        setStat("regen_manaPoint", item.regen_manaPoint);
        setStat("wildPoint", item.wildPoint);
        setStat("regen_wildPoint", item.regen_wildPoint);
        setStat("energyPoint", item.energyPoint);
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