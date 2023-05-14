using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectorCameraController : MonoBehaviour
{
    public float sensitivityX = 2;
    public float sensitivityY = 2;

    [SerializeField] private int maxAngleUp = 65; //вниз
    [SerializeField] private int maxAngleDown = 65; //вверх
    [SerializeField] private int maxAngleLeft = 65; 
    [SerializeField] private int maxAngleRight = 65; 

    Vector3 rot = new Vector3(0, 0, 0);

    [SerializeField] private Transform aimTarget;
    [SerializeField] private float multy;
    [SerializeField] private float aimLerp;


    public void ChangeSensitivity(int x, int y)
    {
        sensitivityX = x;
        sensitivityY = y;
    }

    void Update()
    {

        Ray desiredTargetRay = gameObject.GetComponent<Camera>().ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
        Vector3 desiredTargetPosition = desiredTargetRay.origin + desiredTargetRay.direction * multy;
        aimTarget.position = Vector3.Lerp(aimTarget.position, desiredTargetPosition, aimLerp * Time.deltaTime);

        float MouseX = Input.GetAxis("Mouse X") * sensitivityX;
        float MouseY = Input.GetAxis("Mouse Y") * sensitivityY;

        rot.x = rot.x - MouseY;
        if (rot.x > maxAngleDown)
        {
            rot.x = maxAngleDown;
        }
        if (rot.x < -maxAngleUp)
        {
            rot.x = -maxAngleUp;
        }
        if (rot.y > maxAngleRight)
        {
            rot.y = maxAngleRight;
        }
        if (rot.y < -maxAngleLeft)
        {
            rot.y = -maxAngleLeft;
        }
        rot.y = rot.y + MouseX;

        transform.eulerAngles = rot;
    }
}
