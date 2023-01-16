using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasicBehaviour 
{
    public PlayableAgent playableAgent { get; set; }

    public notPlayableAgent notPlayableAgent { get; set; }

    public AgentObject agent { get; set; }
    public abstract void makeanAttack(GameObject player, GameObject enemy, bool inRange);
    public abstract void makeanAbility(GameObject player, Vector3 position);
    public abstract void makeaDesicion();

    public BasicBehaviour(PlayableAgent playableAgent, notPlayableAgent notPlayableAgent, AgentObject agent)
    {
        this.playableAgent = playableAgent;
        this.notPlayableAgent = notPlayableAgent;

        this.agent = agent;
        if (playableAgent != null)
        {
            this.agent = playableAgent;
        }
        else if (notPlayableAgent != null)
        {
            this.agent = notPlayableAgent;
        } 
    }

    
}
