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

    public PlayableAgent agent_base;
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
        
        //agentStats = new dictionary();
        
        //agentStats.setplayableagentBaseStats(agent);


        //create a new instance of the makeanattack class
        //add the agent to the makeanattack class
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if (agent.spellTarget == null)
            {
                Debug.Log("Target is null");
                return;
            }
            BasicBehaviour behaviour = new MakeAnBehaviour(agent, null, null);
            behaviour.makeanAbility(this.gameObject, null, spells[2], cooldownCalculator, 2);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (agent.spellTarget == null)
            {
                Debug.Log("Target is null");
                return;
            }
            spell.CreateSpell(spells[3], this.gameObject, agent.spellTarget);
            spellBarManager.SpellCasted(3);
        }
    }

    
 
}
