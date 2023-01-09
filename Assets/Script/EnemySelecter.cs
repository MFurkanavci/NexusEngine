using UnityEngine;

public class EnemySelecter : MonoBehaviour
{
    public GameObject selectedEnemy;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                GameObject enemy = hit.transform.gameObject;

                if (enemy.tag == "Mob")
                {
                    selectedEnemy = enemy;
                }
                else
                {
                    selectedEnemy = null;
                }
            }
        }
    }

    public GameObject GetSelectedEnemy()
    {
        return selectedEnemy;
    }

    public void SetSelectedEnemy(GameObject enemy)
    {
        selectedEnemy = enemy;
    }

    public void ClearSelectedEnemy()
    {
        selectedEnemy = null;
    }

    public bool IsEnemySelected()
    {
        if (selectedEnemy != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
