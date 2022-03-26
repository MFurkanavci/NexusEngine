using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseManager : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Mob")
        {
            Destroy(other.gameObject);
        }
    }
}
