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
        GCD.GCD gCD = new GCD.GCD();
        //here will be called when the agent is attacking an enemy with in range, so the agent will be attacking the enemy
        //check if the global cooldown is ready to attack if it is then attack and set the global cooldown to the attack speed of the agent
        gCD = player.GetComponent<Controller_ClicktoMove>().gCD;
        if (gCD.gcdReady())
        {
            gCD.Update(agent.speed_Attack);
            player.GetComponent<SpellCreater>().CreateSpell(agent.activeSpells[0], player, agent.spellTarget);
            gCD.Set(agent.speed_Attack);
            player.GetComponent<Controller_ClicktoMove>().gCD.Set(agent.speed_Attack);
            
        }
    }

    public override void makeanAbility(GameObject player, GameObject enemy,SpellArchitecture spell)
    {
        GCD.GCD gCD = new GCD.GCD();
        gCD.Update(spell.delayTime);
        if (gCD.gcdReady())
        {
            Debug.Log("Fix this");
            player.GetComponent<SpellCreater>().CreateSpell(spell, player, enemy);
            gCD.Set(spell.delayTime);
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
