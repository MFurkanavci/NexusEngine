using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

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
}

