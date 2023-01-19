using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum mobType
{
    SmallMob,
    MediumMob,
    largeMob,
    Boss,
}
[CreateAssetMenu(fileName = "New not Playable Agent", menuName = "Agent System/Agents/notPlayableAgent")]
public class notPlayableAgent : AgentObject
{
    public mobType mobType;

    public void Awake()
    {
        type = agentType.notPlayable;
        ID = 1001 + uniqueID.nextagent++;
    }
}
