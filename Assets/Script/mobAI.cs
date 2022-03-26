using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class mobAI : MonoBehaviour
{
    private NavMeshAgent _agent;

   public Vector3 
        _movePoint
        ;

    

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    public void Destination(Vector3 _destination)
    {
        _agent.SetDestination( _destination);

    }
}
