using UnityEngine;

namespace MousePosition
{
    public static class MousePosition
    {
        public static Vector3 GetMousePosition()
        {
            //make a ray from the camera to the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            //if the ray hits something
            if (Physics.Raycast(ray, out hit, 100))
            {
                //return the position of the hit
                hit.point = new Vector3(hit.point.x, hit.point.y + 0.2f, hit.point.z);
                return hit.point;
            }
            //if the ray doesn't hit anything return the position of the mouse
            return Input.mousePosition;
        }
    }
}
