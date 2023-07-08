using UnityEngine;
using UnityEngine.AI;

public class Controller_ClicktoMove : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    public GameObject click;

    private NavMeshAgent agentNM;

    private PlayableAgent agent;

    private MakeAnBehaviour behaviour;

    private Targeter targeter;

    public GameObject target;
    public GameObject spellTarget;

    public bool isInRange = false;

    private void Start()
    {
        agentNM = GetComponent<NavMeshAgent>();
        agent = GetComponent<Player>().agent;
        targeter = new Targeter(agent, null, null);
        behaviour = new MakeAnBehaviour(agent, null, null);

        if (_mainCamera == null)
        {
            _mainCamera = Camera.main;
        }

        if(agent.activeSpells[0] == null)
        {
            return;
        }

        if(agent.activeSpells[0].maxlenght < agent.damage_range)
        {
            agent.activeSpells[0].maxlenght = agent.damage_range;
        }
        else
        {
            agent.damage_range = agent.activeSpells[0].maxlenght;
        }

    }

    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            {
                SetSpellTarget(GetTarget());
                CalculateRaycast();
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            {
                SetSpellTarget(GetTarget());
            }
        }

        agentNM.speed = agent.speed_Movement;

        if (target != null)
        {
            Move(target);
        }
        else
        {
            agent.enemyTarget = null;
            isInRange = false;
        }

        if (spellTarget != null)
        {
            agent.spellTarget = spellTarget;
        }
        else
        {
            agent.spellTarget = null;
        }
    }

    private void OnDrawGizmos()
    {
        if (agent == null)
            return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, agent.damage_range);
    }

    public void CalculateRaycast()
    {
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            if (hit.transform.tag == "Ground" || hit.transform.tag == "Spell")
            {
                Move(hit.point);
                target = null;
                targeter.ClearTarget();
            }
            else if (hit.transform.tag == "Mob")
            {
                target = hit.transform.gameObject;
                targeter.SetTarget(target);
            }
        }
    }

    public void Move(Vector3 point)
    {
        agentNM.SetDestination(point);
    }

    public bool IsTargetInRange()
    {
        return isInRange;
    }

    public void Move(GameObject targetObject)
    {
        if (IsTargetInRange())
        {
            behaviour.MakeAnAttack(gameObject, targetObject, GetComponent<Player>().cooldownCalculator);
        }
        else
        {
            agentNM.SetDestination(ClosestPoint(IsTargetInRange()));
        }
        ClosestPoint(IsTargetInRange());
    }


    public Vector3 ClosestPoint(bool isTargetInRange)
    {
        float distance = Vector3.Distance(transform.position, target.transform.position);
        Vector3 closestPoint = target.GetComponent<Collider>().ClosestPoint(transform.position);
        Vector3 offset = closestPoint - transform.position;
        offset = offset.normalized * agent.damage_range;
        closestPoint = transform.position + offset;
        if (distance <= agent.damage_range - 0.5f && !isTargetInRange)
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

    public GameObject GetTarget()
    {
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            if (hit.transform.tag == "Ground")
            {
                spellTarget = null;
                targeter.ClearTarget();
            }
            else if (hit.transform.tag == "Mob")
            {
                spellTarget = hit.transform.gameObject;
            }
        }
        return spellTarget;
    }

    public void SetTarget(GameObject target)
    {
        this.target = target;
    }

    public void SetSpellTarget(GameObject target)
    {
        this.spellTarget = target;
    }

    Vector3 GetTargetPosition()
    {
        return target.transform.position;
    }
}
