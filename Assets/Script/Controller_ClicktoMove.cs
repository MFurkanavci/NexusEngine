using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Controller_ClicktoMove : MonoBehaviour
{

    [SerializeField] Camera _mainCamera;
    public GameObject click;

    private NavMeshAgent agentNM;

    private PlayableAgent agent;

    private MakeAnBehaviour behaviour;

    private Targeter targeter;

    public GameObject target;

    private void Awake()
    {
        agentNM = GetComponent<NavMeshAgent>();
        agent = gameObject.GetComponent<Player>().agent;
        behaviour = new MakeAnBehaviour(agent, null, null);
        targeter = new Targeter(agent, null, null);
        
    }


    private void Update()
    {
        if(Input.GetMouseButton(1))
        {
            move();
        }
        behaviour.makeanAttack(gameObject, target, isClosestPoint(target));
    }

    //draw range of the agent
    private void OnDrawGizmos()
    {
        if (agent == null)
            return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, agent.damage_range);
    }
    
    //chekc if the raycast hit something
    //if it hit .tag == "Ground" then move to the point
    //if it hit .tag == "Mob" then calculate the agent.damage_range and move to the closest point

    public void move()
    {
        Ray _Ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit _isHit;

        if (Physics.Raycast(_Ray, out _isHit, 100))
        {
            if (_isHit.transform.tag == "Ground")
            {
                agentNM.destination = _isHit.point;
                
                var click_GO = Instantiate(click);
                click_GO.transform.position = new Vector3(_isHit.point.x, _isHit.point.y + 0.2f, _isHit.point.z);
                Destroy(click_GO, .2f);
            }
            else if (_isHit.transform.tag == "Mob")
            {
                target = _isHit.transform.gameObject;
                setTarget(_isHit.transform.gameObject);
                targeter.setTarget(null);
                agentNM.destination = closestPoint(_isHit.transform.gameObject);
            }
            else if(_isHit.transform.tag == "Ally")
            {
                targeter.setTarget(null);
                agentNM.destination = closestPoint(_isHit.transform.gameObject);
            }
            else if (_isHit.transform.tag == "Player")
            {
                targeter.setTarget(null);
                agentNM.destination = closestPoint(_isHit.transform.gameObject);
            }
            else if (_isHit.transform.tag == "Interactable")
            {
                targeter.setTarget(null);
                agentNM.destination = closestPoint(_isHit.transform.gameObject);
            }
            else
            {
                targeter.clearTarget();
            }
        }
    }

    public Vector3 closestPoint(GameObject target)
    {
        var distance = Vector3.Distance(transform.position, target.transform.position);

        if (distance <= agent.damage_range)
        {
            return transform.position;
        }
        else
        {
            var closestPoint = target.transform.position + (transform.position - target.transform.position).normalized * agent.damage_range;
            return closestPoint;
        }
    }

    public GameObject getTarget()
    {
        return target;
    }

    public void setTarget(GameObject target)
    {
        targeter.setTarget(target);
    }

    public bool isClosestPoint(GameObject target)
    {
        if (target == null)
        {
            return false;
        }
        var distance = Vector3.Distance(transform.position, target.transform.position);

        if (distance <= agent.damage_range + .1f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }        

}
