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
        agent_base = PlayableAgent.CreateInstance("PlayableAgent") as PlayableAgent;
        agent_base = agent;
        agentStats = new dictionary();
        agentStats.setagentBaseStats(agent_base);
    }
}
