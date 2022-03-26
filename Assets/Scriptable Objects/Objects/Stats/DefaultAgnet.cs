using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Default Agent", menuName ="Agent System/Agents/DefaultAgent")]
public class DefaultAgnet : AgentObject
{

    public void Awake()
    {
        type = agentType.Default;
    }

}
