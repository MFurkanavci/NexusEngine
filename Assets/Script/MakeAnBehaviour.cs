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
        //here will be called when the agent is attacking an enemy with in range, so the agent will be attacking the enemy
        //check if the global cooldown is ready to attack if it is then attack and set the global cooldown to the attack speed of the agent
        if (GCD.GCD.gcdReady())
        {
            //attack the enemy
            float damage = 0;
            damage += agent.damageCalculations.DealDamage(agent.damageCalculations.damageTypeandValue(agent.damageCalculations.GetDamageType(), agent.damage_Physical));
            agent.enemyTarget.hitPoint -= damage;
            GCD.GCD.Set(agent.speed_Attack);
            
        }
    }

    public override void makeanAbility(GameObject player, Vector3 position)
    {
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
