using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this is the player indicator for some other scripts

public class Player : MonoBehaviour
{

    public PlayableAgent agent_base;
    public PlayableAgent agent;

    public Item[] inventory = new Item[6];

    
    public dictionary agentStats;

    public void Awake()
    {
        //agent must be copy of the agent_base 
        //agent_base should not change
        //so create a new agent and copy the agent_base to it just for the instance

        agent =  PlayableAgent.CreateInstance("PlayableAgent") as PlayableAgent;

        foreach (var item in agent_base.GetType().GetFields())
        {
            item.SetValue(agent, item.GetValue(agent_base));
        }



        agentStats = new dictionary();
        setagentBaseStats(agent);
    }

    public void setagentBaseStats(PlayableAgent agent)
    {
        agentStats.setagentBaseStats(agent);
    }
}
