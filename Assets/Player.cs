using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    //make a constractor for the player class
    //and set the agent_base to the agent in the constractor
    //and then copy the agent_base to the agent
    //and then set the agentStats to the agentBaseStats




public class Player : MonoBehaviour
{

    public PlayableAgent agent_base;
    public PlayableAgent agent;

    public Item[] inventory = new Item[6];

    
    public dictionary agentStats;

    public Player()
    {
    }

    public void Awake()
    {
        
        agent =  PlayableAgent.CreateInstance("PlayableAgent") as PlayableAgent;

        foreach (var item in agent_base.GetType().GetFields())
        {
            item.SetValue(agent, item.GetValue(agent_base));
        }
        
        agentStats = new dictionary();
        
        agentStats.setplayableagentBaseStats(agent);

        //create a new instance of the makeanattack class
        //add the agent to the makeanattack class
    }


}
