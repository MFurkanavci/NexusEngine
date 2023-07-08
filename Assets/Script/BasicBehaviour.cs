using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasicBehaviour 
{
    public PlayableAgent playableAgent { get; set; }

    public notPlayableAgent notPlayableAgent { get; set; }

    public AgentObject agent { get; set; }
    public abstract void MakeAnAttack(GameObject player, GameObject enemy,CooldownCalculator cooldownCalculator);
    public abstract void MakeAnAbility(GameObject player, GameObject enemy,SpellArchitecture spell,CooldownCalculator cooldownCalculator, int spellIndex);
    public abstract void MakeADesicion();

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
