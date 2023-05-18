using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DPS : MonoBehaviour
{
    //this script is the calculation for the damage per second of the agent

    public float damage;
    public float attackSpeed;
    public float dps;

    private PlayableAgent agent;

    private void Start()
    {
        agent = this.gameObject.GetComponent<Player>().agent;
        damage = agent.damage_Physical;
    }

    private void Update()
    {
    }



}
