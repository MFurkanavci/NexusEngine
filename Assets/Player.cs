using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    //make a constractor for the player class
    //and set the agent_base to the agent in the constractor
    //and then copy the agent_base to the agent
    //and then set the agentStats to the agentBaseStats




public class Player : MonoBehaviour
{

    public AgentObject agent_base;
    public PlayableAgent agent;
    public List<Spells> spells = new List<Spells>();
    public Item[] inventory = new Item[6];
    public dictionary agentStats;

    public SpellCreater spell;

    public SpellBarManager spellBarManager;

    public CooldownCalculator cooldownCalculator;

    public Player()
    {
        
    }

    public void Awake()
    {
        
        agent = ScriptableObject.CreateInstance<PlayableAgent>();
        agent.CopyFrom(agent_base);

        foreach (var item in agent_base.activeSpells)
        {
            Spells spell = ScriptableObject.CreateInstance<Spells>();
            spell.CopyFrom(item);
            spells.Add(spell);
        }

        
        spell = this.gameObject.AddComponent<SpellCreater>();

        cooldownCalculator = GetComponent<CooldownCalculator>();
        cooldownCalculator.InitializeAbilityData(agent.activeSpells);
        
        agentStats = new dictionary();
        
        agentStats.setplayableagentBaseStats(agent);
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            BasicBehaviour behaviour = new MakeAnBehaviour(agent, null, null);
            behaviour.makeanAbility(this.gameObject, agent.spellTarget, spells[2], cooldownCalculator, 2);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            BasicBehaviour behaviour = new MakeAnBehaviour(agent, null, null);
            behaviour.makeanAbility(this.gameObject, agent.spellTarget, spells[3], cooldownCalculator, 3);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            BasicBehaviour behaviour = new MakeAnBehaviour(agent, null, null);
            behaviour.makeanAbility(this.gameObject, agent.spellTarget, spells[4], cooldownCalculator, 4);
        }
    }

    
 
}
