using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New not Playable Agent", menuName = "Agent System/Agents/notPlayableAgent")]
public class notPlayableAgent : AgentObject
{

    public void Awake()
    {
        type = agentType.notPlayable;
        ID = 1001 + uniqueID.nextagent++;
    }
}
