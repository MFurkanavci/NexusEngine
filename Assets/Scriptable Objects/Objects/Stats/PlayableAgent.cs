using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Classes
{
    Tank,
    Support,
    Healer,
    Melee_DPS,
    Range_DPS
}

[CreateAssetMenu(fileName = "New Playable Agent", menuName = "Agent System/Agents/PlayableAgent")]
public class PlayableAgent : AgentObject
{

    public Classes classes;

    public void Awake()
    {
        type = agentType.Playable;
        ID = 1001 + uniqueID.nextagent++;
    }
}

