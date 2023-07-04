using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GCD;  // <--- This is the namespace of the GCD.cs file
using TMPro;

public class MakeAnBehaviour : BasicBehaviour
{
    

    public MakeAnBehaviour(PlayableAgent playableAgent, notPlayableAgent notPlayableAgent, AgentObject agent) : base(playableAgent, notPlayableAgent, agent)
    {
        
    }

    public AgentObject getAgent()
    {
        return agent;
    }
    public override void makeanAttack(GameObject player, GameObject enemy)
    {
        
        
        if (GCD.GCD.gcdReady())
        {
            player.GetComponent<SpellCreater>().CreateSpell(agent.activeSpells[0], player, enemy);
            GCD.GCD.Set(agent.speed_Attack);
            player.GetComponent<Player>().spellBarManager.SpellCasted(0);

        }
        
    }

    public override void makeanAbility(GameObject player, GameObject enemy,SpellArchitecture spell,CooldownCalculator cooldownCalculator, int spellIndex)
    {
        
        if(!cooldownCalculator.IsAbilityOnCooldown(spell))
        {
            player.GetComponent<SpellCreater>().CreateSpell(spell, player, agent.spellTarget);
            cooldownCalculator.StartCooldown(spell);
            player.GetComponent<Player>().spellBarManager.SpellCasted(spellIndex);
        }
    }
    public override void makeaDesicion()
    {
        //Debug.Log("Desicion");
    }
    
    public void Update()
    {
        //keep updating the global cooldown for the agent

    }

    enum AgentState
    {
        Idle,
        Moving,
        Attacking,
        Ability,
        Dead
    }

    enum DamageType
    {
        Physical,
        Magical,
        True
    }

}
