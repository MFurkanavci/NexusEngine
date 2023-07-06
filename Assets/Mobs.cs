using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mobs : MonoBehaviour
{
    public AgentObject agent_base;
    public notPlayableAgent agent;

    public Item[] inventory = new Item[6];

    public MakeAnBehaviour behaviour;

    public Targeter targeter;

    
    public dictionary agentStats;

    public Mobs()
    {
    }

    public void Awake()
    {
        
        agent =  notPlayableAgent.CreateInstance("notPlayableAgent") as notPlayableAgent;
        agent.CopyFrom(agent_base);
        
        //agentStats = new dictionary();
        
        //agentStats.setnotplayableagentStats(agent);
        
        //targeter = new Targeter(null,agent,null);

        //behaviour =  new MakeAnBehaviour(null,agent,null);

       
    }

    public void Update()
    {
        if(stillAlive())
        {
            return;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public bool stillAlive()
    {
        if(agent.hitPoint <= 0)
        {
            agent.isAlive = false;
            return false;
        }
        else
        {   
            agent.isAlive = true;
            return true;
        }
    }
}
