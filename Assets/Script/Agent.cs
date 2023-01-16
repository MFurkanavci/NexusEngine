using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class Agent : MonoBehaviour
{
    public PlayableAgent agent_base;
    public PlayableAgent agent;
    public Item[] inventory = new Item[6];

    public dictionary agentStats, itemStats;

    

    [Range(0,100)]
    public int max_HP;

    private int elapsedTime;


    public void Awake()
    {
        
        agentStats = new dictionary();
        itemStats = new dictionary();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            equip();
        }
        if(Input.GetKeyDown(KeyCode.F))
        {
            unequip();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            var x = agent_base.activeSpells[0];
            x.SpellTypeSelecter();

        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            agentStats.printFilteredStats();
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            itemStats.printFilteredStats();

        }
    }

   // public void fieldFinder(Item item, PlayableAgent agent)
    //{
      //  foreach (var itemStat in item.GetType().GetFields())
       // {
         //   foreach (var agentStat in agent.GetType().GetFields())
           // {
             //   if (agentStat.Name == itemStat.Name)
               // {
                 //   if (agentStat.FieldType == typeof(float))
                   // {
                    //    agentStat.SetValue(agent, (float)agentStat.GetValue(agent) + (float)itemStat.GetValue(item));
                    //}
                //}
            //}
       // }
   // }


    public void equip()
    {
        foreach (Item item in inventory)
        {
            if (item != null)
            {
                if (item.isEquipable)
                {
                    if (!item.isEquipped)
                    {
                        item.isEquipped = true;
                        itemStats.setitemBaseStats(item);
                        agentStats.addStat(itemStats.stats);
                    }
                }
            }
        }
        
    }
    public void unequip()
    {
        foreach (Item item in inventory)
        {
            if (item != null)
            {
                if (item.isEquipable)
                {
                    if (item.isEquipped)
                    {
                        item.isEquipped = false;
                        itemStats.setitemBaseStats(item);
                        agentStats.removeStat(itemStats.stats);
                    }
                }
            }
        }
    }

    //public void OnTriggerStay(Collider other)
    //{
    //    if (other.tag == "Enemy")
    //    {
    //        if (Input.GetKey(KeyCode.G))
    //        {
    //            other.GetComponent<Agent>().agent.hitPoint -= agent.damage_Physical*Time.time;

    //            print("Damage:" + agent.damage_Physical);
    //        }
    //    }
    //}

    //public bool Rate()
    //{
    //    if (Time.time > elapsedTime)
    //    {
    //        return true;
    //    }
    //    else
    //        return false;
    //}

    //public void Hit(GameObject other)
    //{
    //    other.GetComponent<Agent>().agent.hitPoint -= agent.damage_Physical * Time.deltaTime;
    //    Debug.Log(other.GetComponent<Agent>().agent.hitPoint);
    //}
}

