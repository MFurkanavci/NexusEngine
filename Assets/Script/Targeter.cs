using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeter : MakeAnBehaviour
{


    public Targeter(PlayableAgent playableAgent, notPlayableAgent notPlayableAgent, AgentObject agent) : base(playableAgent, notPlayableAgent, agent)
    {
    }
    public bool checkAgentType()
    {
        //check the agent type and return true if it is a player
        if (agent.GetType() == typeof(PlayableAgent))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void setTarget(GameObject enemy)
    {
        //check the agent type and set the target
        if (checkAgentType())
        {
            //check _ishit is an enemy
            if(targetTag(_isHit()) == "Mob")
            {
                agent.enemyTarget = _isHit().transform.parent.GetComponent<Mobs>().agent;
                Debug.Log("Target is an Enemy");
            }
            else if(targetTag(_isHit()) == "Player")
            {
                agent.allyTarget = _isHit().transform.parent.GetComponent<Player>().agent;
                Debug.Log("Target is an Player");
            }
            else if(targetTag(_isHit()) == "Ally")
            {
                agent.allyTarget = _isHit().transform.parent.GetComponent<Player>().agent;
                Debug.Log("Target is an Player");
            }
            else
            {
                Debug.Log("Target is null");
            }

        }
        else if (!checkAgentType())
        {
            Collider[] enemies = Physics.OverlapSphere(enemy.transform.position, agent.damage_range);
            Collider closestPlayer = null;
            float distance = agent.damage_range;
            Vector3 position = enemy.transform.position;
            foreach (Collider player in enemies)
            {
                if(player != null && player.tag == "Player")
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
                Debug.Log(closestPlayer.name);
                agent.allyTarget = closestPlayer.transform.parent.GetComponent<Player>().agent;
                Debug.Log("Target is an Player");
            }
            else
            {
                Debug.Log("Target is null");
            }

        }
        else
        {
            Debug.Log("Target is null");
        }
    }

    public AgentObject getTarget()
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

    public void clearTarget()
    {
        agent.enemyTarget = null;
        agent.allyTarget = null;
    }

    public GameObject _isHit()
    {
        //check if the raycast hit something
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
    

    public string targetTag(GameObject target)
    {
        if (target == null)
        {
            return "Null";
        }
        //check the tag of the target
        if (target.tag == "Mob")
        {
            return "Mob";
        }
        else if (target.tag == "Ally")
        {
            return "Ally";
        }
        else if (target.tag == "Player")
        {
            return "Player";
        }
        else if (target.tag == "Interactable")
        {
            return "Interactable";
        }
        else
        {
            return "Null";
        }
    }

    

}
