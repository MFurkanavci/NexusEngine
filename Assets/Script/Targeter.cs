using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeter : MakeAnBehaviour
{
    public Targeter(PlayableAgent playableAgent, notPlayableAgent notPlayableAgent, AgentObject agent) : base(playableAgent, notPlayableAgent, agent)
    {
    }

    public bool CheckAgentType()
    {
        return agent.GetType() == typeof(PlayableAgent);
    }

    public void SetTarget(GameObject enemy)
    {
        if (CheckAgentType())
        {
            string targetTag = TargetTag(enemy);
            if (targetTag == "Mob")
            {
                agent.enemyTarget = enemy.transform.GetComponent<Mobs>().agent;
            }
            else if (targetTag == "Player" || targetTag == "Ally")
            {
                agent.allyTarget = enemy.transform.GetComponent<Player>().agent;
            }
            else
            {
                Debug.Log("Target is null");
            }
        }
        else
        {
            Collider[] enemies = Physics.OverlapSphere(enemy.transform.position, agent.damage_range);
            Collider closestPlayer = null;
            float distance = agent.damage_range;
            Vector3 position = enemy.transform.position;
            foreach (Collider player in enemies)
            {
                if (player != null && player.tag == "Player")
                {
                    Vector3 diff = player.transform.position - position;
                    float curDistance = diff.sqrMagnitude;
                    if (curDistance < distance)
                    {
                        closestPlayer = player;
                        distance = curDistance;
                    }
                }
            }

            if (closestPlayer != null)
            {
                agent.allyTarget = closestPlayer.transform.parent.GetComponent<Player>().agent;
                Debug.Log("Target is a Player");
            }
            else
            {
                Debug.Log("Target is null");
            }
        }
    }

    public AgentObject GetTarget()
    {
        if (agent.enemyTarget != null)
        {
            return agent.enemyTarget;
        }
        else if (agent.allyTarget != null)
        {
            return agent.allyTarget;
        }
        else
        {
            return null;
        }
    }

    public void ClearTarget()
    {
        agent.enemyTarget = null;
        agent.allyTarget = null;
        agent.spellTarget = null;
    }

    public GameObject IsHit()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100))
        {
            return hit.transform.gameObject;
        }
        else
        {
            return null;
        }
    }

    public string TargetTag(GameObject target)
    {
        if (target == null)
        {
            return "Null";
        }

        string tag = target.tag;
        if (tag == "Mob" || tag == "Ally" || tag == "Player" || tag == "Interactable")
        {
            return tag;
        }
        else
        {
            return "Null";
        }
    }
}
