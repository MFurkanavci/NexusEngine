using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class Agent : MonoBehaviour
{
    public PlayableAgent agent_base;
    public PlayableAgent agent;
    public Item[] inventory = new Item[6];

    

    [Range(0,100)]
    public int max_HP;

    private int elapsedTime;


    public void Awake()
    {
        //agent = PlayableAgent.CreateInstance("PlayableAgent") as PlayableAgent;
        //agent = agent_base;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            equip(0);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            var x = agent.activeSpells[0];
            switch (x.type)
            {
                case SpellArcType.Projectile:
                    x.ProjectileSpawn();
                    break;

            }

        }
    }

    public void fieldFinder(Item item, PlayableAgent agent)
    {
        foreach (var itemStat in item.GetType().GetFields())
        {
            foreach (var agentStat in agent.GetType().GetFields())
            {
                if (agentStat.Name == itemStat.Name)
                {
                    if (agentStat.FieldType == typeof(float))
                    {
                        agentStat.SetValue(agent, (float)agentStat.GetValue(agent) + (float)itemStat.GetValue(item));
                    }
                }
            }
        }
    }


    public void equip(int slot)
    {
        fieldFinder(inventory[slot], agent);
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

