using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCalculations : MonoBehaviour
{
    private float physicalDamage;
    private float magicalDamage;
    private float trueDamage;
    private float physicalResistance;
    private float magicalResistance;
    private float cachedDamage;

    public DamageType damageType;

    public AgentObject agent;

    public void Start()
    {
        if(GetComponent<Player>() != null)
        {
            agent = GetComponent<Player>().agent as PlayableAgent;
        }
        else if(GetComponent<Mobs>() != null)
        {
            agent = GetComponent<Mobs>().agent as notPlayableAgent;
        }
//        Debug.Log(agent.GetType());
        
        agent.damageCalculations = this;
    }

    public float RecieveDamage(float damage, DamageType type)
    {
        float totalDamage = 0;
        switch (type)
        {
            case DamageType.Physical:
                totalDamage = damage * (100 /(100 + agent.armor_Physical));
                break;
            case DamageType.Magical:
                totalDamage = damage * (100 / (100 + agent.armor_Magical));
                break;
            case DamageType.True:
                totalDamage = damage;
                break;
        }

        if (cachedDamage != totalDamage)
        {
            // update the cached damage
            cachedDamage = totalDamage;
        }
        print("Recieved damage: " + totalDamage);
        return totalDamage;
    }

    public float DealDamage(Dictionary<DamageType, float> damageTypeandvalue)
    {
        float totalDamage = 0;
        float dealedDamage = 0;
        foreach (KeyValuePair<DamageType, float> damageType in damageTypeandvalue)
        {
            print("Damage type: " + damageType.Key);
            print("Damage value: " + damageType.Value);
            switch (damageType.Key)
            {
                case DamageType.Physical:
                    totalDamage = damageType.Value;
                    break;
                case DamageType.Magical:
                    totalDamage = damageType.Value;
                    break;
                case DamageType.True:
                    totalDamage = damageType.Value;
                    break;
            }
            
           dealedDamage += agent.enemyTarget.damageCalculations.RecieveDamage(totalDamage, damageType.Key);
            
        }
        return dealedDamage;
    }
    public float DealDamage(GameObject target, Dictionary<DamageType, float> damageTypeandvalue)
    {
        
        float totalDamage = 0;
        float dealedDamage = 0;
        foreach (KeyValuePair<DamageType, float> damageType in damageTypeandvalue)
        {
            switch (damageType.Key)
            {
                case DamageType.Physical:
                    totalDamage = damageType.Value;
                    break;
                case DamageType.Magical:
                    totalDamage = damageType.Value;
                    break;
                case DamageType.True:
                    totalDamage = damageType.Value;
                    break;
            }
            
           dealedDamage += agent.enemyTarget.damageCalculations.RecieveDamage(totalDamage, damageType.Key);
            
        }
        return dealedDamage;
    }

    

    //create a dictionary for the damage types and their values
    //will recieve the damage type and the value
    public Dictionary<DamageType, float> damageTypeandValue(DamageType damageType, float damageValue)
    {
        Dictionary<DamageType, float> damageTypes = new Dictionary<DamageType, float>();
        damageTypes.Add(damageType, damageValue);
        return damageTypes;
    }

    public DamageType GetDamageType()
    {
        return damageType;
    }


    public enum DamageType
    {
        Physical,
        Magical,
        True
    }
}
