using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ReDrect : MonoBehaviour
{
    public Transform _nextPoint;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Mob")
        {
            other.GetComponent<NavMeshAgent>().destination = _nextPoint.position;
        }
    }
}
