using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName ="New Default Agent", menuName ="Agent System/Agents/DefaultAgent")]
public class DefaultAgnet : AgentObject
{
private static int nextPlayableAgentID = 1000;

    private void OnEnable()
    {
        type = agentType.Default;
        ID = GeneratePlayableAgentID();
    }

    private static int GeneratePlayableAgentID()
    {
        //check if the ID is already in use in the asset database
        if (AssetDatabase.FindAssets("t:AgentObject").Length > 0)
        {
            //get all the assets
            string[] guids = AssetDatabase.FindAssets("t:AgentObject");
            //loop through all the assets
            for (int i = 0; i < guids.Length; i++)
            {
                //get the asset path
                string path = AssetDatabase.GUIDToAssetPath(guids[i]);
                //get the asset
                AgentObject agent = AssetDatabase.LoadAssetAtPath<AgentObject>(path);
                //check if the ID is the same
                if (agent.ID == nextPlayableAgentID)
                {
                    //increase the ID
                    nextPlayableAgentID++;
                }
            }
        }
        //return the ID
        return nextPlayableAgentID;
    }
}
