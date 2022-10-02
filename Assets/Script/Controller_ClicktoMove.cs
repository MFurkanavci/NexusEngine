using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Controller_ClicktoMove : MonoBehaviour
{

    [SerializeField] Camera _mainCamera;
    public GameObject click;

    private NavMeshAgent agent;



    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        
    }


    private void Update()
    {
        if(Input.GetMouseButton(1))
        {
            Ray _Ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit _isHit;

            if(Physics.Raycast(_Ray,out _isHit,100))
            {
                agent.destination = _isHit.point;
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            var click_GO = Instantiate(click);
            Ray _Ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit _isHit;
            if (Physics.Raycast(_Ray, out _isHit, 100))
            {
                click_GO.transform.position = new Vector3(_isHit.point.x, _isHit.point.y + 0.2f, _isHit.point.z);
                Destroy(click_GO, .2f);
            }
            
        }
    }
}
