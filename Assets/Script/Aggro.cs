using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;




public class Aggro : MonoBehaviour
{
    private Agent agent;
    [SerializeField]

    public float ranges;
    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Mob")
        {
            //float aggroFadingTime;
            other.GetComponent<NavMeshAgent>().isStopped = true;
            other.gameObject.transform.rotation = Quaternion.RotateTowards(other.transform.rotation, Quaternion.LookRotation(gameObject.transform.position - other.transform.position), Time.time * 1.5f);
            float closestPoint = Vector3.Distance(other.transform.position, gameObject.transform.position);
            if (closestPoint  >= ranges)
            {
               // other.transform.position = Vector3.Lerp(other.transform.position, gameObject.transform.position, 1.5f * Time.deltaTime);

            }
                

        }
    }
    IEnumerator Fadeout(float time)
    {
        yield return new WaitForSeconds(time);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Mob")
        {
            other.GetComponent<NavMeshAgent>().isStopped = false;
        }
    }
}
