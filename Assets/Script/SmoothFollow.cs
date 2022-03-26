using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
    public Transform
        Target,
        camTransform
        ;

    public Vector3
        offset,
        velocity = Vector3.zero
        ;

    public float
        camSpeed,
        screenSizeThickness,
        bottom_T
        ;

    public float smoothTime = .5f;

    private void Awake()
    {
        offset = camTransform.position - Target.position;
    }

    private void LateUpdate()
    {
        Vector3 pos = transform.position;

        if (Input.GetKey(KeyCode.Space))
        {
            Vector3 targetPosition = Target.position + offset;

            camTransform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

            transform.LookAt(Target);
        }
        else
        {
            camBehaviour(pos);
        }
    }

    public void camBehaviour(Vector3 pos)
    {
        //up
        if (Input.mousePosition.y >= screenSizeThickness + bottom_T)
        {
            pos.z += camSpeed * Time.deltaTime;
        }
        //down
        if (Input.mousePosition.y <= Screen.height - screenSizeThickness)
        {
            pos.z -= camSpeed * Time.deltaTime;
        }
        //right
        if (Input.mousePosition.x >= Screen.width - screenSizeThickness)
        {
            pos.x += camSpeed * Time.deltaTime;
        }
        //left
        if (Input.mousePosition.x <= screenSizeThickness)
        {
            pos.x -= camSpeed * Time.deltaTime;
        }

        transform.position = pos;
    }
}
