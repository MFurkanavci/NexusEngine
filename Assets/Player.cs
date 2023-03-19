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
    public List<Spells> spells = new List<Spells>();

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

        foreach (var item in agent.activeSpells)
        {
            spells.Add(Spells.CreateInstance("Spells") as Spells);
        }

        for (int i = 0; i < agent.activeSpells.Count; i++)
        {
            foreach (var item in agent.activeSpells[i].GetType().GetFields())
            {
                item.SetValue(spells[i], item.GetValue(agent.activeSpells[i]));
            }
        }


        
        agentStats = new dictionary();
        
        agentStats.setplayableagentBaseStats(agent);


        //create a new instance of the makeanattack class
        //add the agent to the makeanattack class
    }

    public void Update()
    {
        //if the player press q then call spellCreater.createaNewSpell();

        if (Input.GetKeyDown(KeyCode.Q))
        {
            spells[0].target = agent.spellTarget;
            spells[0].player = this.gameObject;

            SpellCreater createaNewSpell = new SpellCreater (spells[0], this.gameObject, agent.spellTarget);
        }
    }
    
}
