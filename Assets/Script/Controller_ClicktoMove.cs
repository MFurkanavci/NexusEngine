using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class Controller_ClicktoMove : MonoBehaviour
{

    [SerializeField] Camera _mainCamera;
    public GameObject click;

    private NavMeshAgent agentNM;

    public PlayableAgent agent;

    private MakeAnBehaviour behaviour;

    private Targeter targeter;

    public GameObject 
        target,
        spellTarget;

    public TMP_Text text;

    public bool isInRange = false;

    private void Start()
    {
        agentNM = GetComponent<NavMeshAgent>();
        agent = this.gameObject.GetComponent<Player>().agent;
        targeter = new Targeter(agent, null, null);
        behaviour = new MakeAnBehaviour(agent, null, null);

        Debug.Log(agent.Name);
        
    }


    private void Update()
    {
        if(Input.GetMouseButton(1))
        {
            //check if the mouse is over the UI
            if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            {
                setSpellTarget(getTarget());
                calculateRaycast();
            }
        }

        if(Input.GetMouseButtonDown(0))
        {
            //check if the mouse is over the UI
            if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            {
                setSpellTarget(getTarget());
            }
        }

        agentNM.speed = agent.speed_Movement;
        
        GCD.GCD.Update(agent.speed_Attack);
        text.text = GCD.GCD.Get().ToString("F2");
            
        
        if(target != null)
        {
            move(target);
        }
        else
        {
            agent.enemyTarget = null;
            isInRange = false;
        }

        if(spellTarget != null)
        {
            agent.spellTarget = spellTarget;
        }
        else
        {
            agent.spellTarget = null;
        }

        
        

    }
    //draw range of the agent
    private void OnDrawGizmos()
    {
        if (agent == null)
            return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, agent.damage_range);
    }



    public void calculateRaycast()
    {
        Ray _Ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit _isHit;
        if (Physics.Raycast(_Ray, out _isHit, 100))
        {
            if (_isHit.transform.tag == "Ground")
            {
                move(_isHit.point);
                target = null;
                targeter.clearTarget();
            }
            else if (_isHit.transform.tag == "Mob")
            {
                target = _isHit.transform.gameObject;
                targeter.setTarget(null);
            }
        }
        
    }

    //move to the point
    public void move(Vector3 point)
    {
        agentNM.SetDestination(point);
    }

    public bool isTargetInRange()
    {
        return isInRange;
    }

    //move to the closest point
    public void move(GameObject target)
    {
        if (isTargetInRange())
        {
            behaviour.makeanAttack(gameObject, target);
        }
        else
        {
            agentNM.SetDestination(closestPoint(isInRange));
        }
        closestPoint(isInRange);
        
    }

    //get the closest point to the target
    public Vector3 closestPoint(bool isTargetInRange)
    {
            
        float distance = Vector3.Distance(transform.position, target.transform.position);    
        Vector3 closestPoint = target.GetComponent<Collider>().ClosestPoint(transform.position);
        Vector3 offset = closestPoint - transform.position;
        offset = offset.normalized * agent.damage_range;
        closestPoint = transform.position + offset;
        if (distance <= agent.damage_range - .5f && !isTargetInRange)
        {
            isInRange = true;
            return transform.position;
        }
        else if (distance > agent.damage_range && isInRange)
        {
            isInRange = false;
            return closestPoint;
        }
        else
        {
            return closestPoint;
        }       
    }

    public GameObject getTarget()
    {
        Ray _Ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit _isHit;
        if (Physics.Raycast(_Ray, out _isHit, 100))
        {
            if (_isHit.transform.tag == "Ground")
            {
                spellTarget = null;
                targeter.clearTarget();
            }
            else if (_isHit.transform.tag == "Mob")
            {
                spellTarget = _isHit.transform.gameObject;
            }
        }
        return spellTarget;
    }

    public void setTarget(GameObject target)
    {
        this.target = target;
    }

    public void setSpellTarget(GameObject target)
    {
        this.spellTarget = target;
    }

    Vector3 getTargetPosition()
    {
        return target.transform.position;
    }

}
