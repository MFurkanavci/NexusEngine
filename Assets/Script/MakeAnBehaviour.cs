using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GCD;  // <--- This is the namespace of the GCD.cs file
using TMPro;

public class MakeAnBehaviour : BasicBehaviour
{

    public TMP_Text text;

    public MakeAnBehaviour(PlayableAgent playableAgent, notPlayableAgent notPlayableAgent, AgentObject agent) : base(playableAgent, notPlayableAgent, agent)
    {
        text = GameObject.Find("GCD").GetComponent<TMP_Text>();
    }

    public AgentObject getAgent()
    {
        return agent;
    }
    public override void makeanAttack(GameObject player, GameObject enemy, bool inRange)
    {
        //calculate the damage if the target is not null and the target is in range
        if (agent.enemyTarget != null && agent.enemyTarget.isAlive)
        {
            //check the distance between the target and the agent
            if (inRange)
            {
                        //check the cooldown is finished
                        if (GCD.GCD.Update(agent.speed_Attack))
                        {
                            //calculate the damage
                            agent.enemyTarget.hitPoint -= agent.damage_Physical;
                            Debug.Log( agent.Name + "'s damage is " + agent.damage_Physical + " and the " +agent.enemyTarget.Name+" HP is " + agent.enemyTarget.hitPoint);
                        }
                        else
                        {
                            //Debug.Log("GCD is not finished");
                            text.text = GCD.GCD.TimeLeft().ToString();

                        }
            }
            else
            {
                Debug.Log(agent.enemyTarget.Name + " is out of range");
            }
        }
        else if (agent.enemyTarget == null)
        {
            //Debug.Log("Target is null");
        }
        else
        {
            Debug.Log(agent.enemyTarget.Name + " is dead");
            agent.enemyTarget = null;
        }
    }

    public override void makeanAbility(GameObject player, Vector3 position)
    {
    }

    public override void makeaDesicion()
    {
        //Debug.Log("Desicion");
    }
    

}
