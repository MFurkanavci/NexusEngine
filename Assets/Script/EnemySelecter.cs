using UnityEngine;

public class targetSelecter : MonoBehaviour
{
    public GameObject selectedTarget;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                GameObject target = hit.transform.gameObject;

                if (target.tag == "Mob")
                {
                    selectedTarget = target;
                }
                else
                {
                    selectedTarget = null;
                }
            }
        }
    }

    public GameObject GetSelectedTarget()
    {
        return selectedTarget;
    }

    public bool IstargetSelected()
    {
        return selectedTarget != null;
    }

    public void DeselectTarget()
    {
        selectedTarget = null;
    }



}
