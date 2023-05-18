using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class mobAI : MonoBehaviour
{
    private NavMeshAgent _agent;
    private notPlayableAgent _agentObject;

   public Vector3 
        _movePoint
        ;

    

    private void Awake()
    {
        _agentObject = GetComponent<Mobs>().agent;
        _agent = GetComponent<NavMeshAgent>();
        _agent.speed = _agentObject.speed_Movement;
    }

    public void Destination(Vector3 _destination)
    {
        _agent.SetDestination( _destination);

    }
}
