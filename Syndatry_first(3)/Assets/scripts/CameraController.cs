using System;
using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject player; //target

    [SerializeField] private float sensitivityX = 2;
    [SerializeField] private float sensitivityY = 2;

    [SerializeField] private int maxAngleUp = 65; //вниз
    [SerializeField] private int maxAngleDown = 65; //вверх

    Vector3 rot = new Vector3(0, 0, 0);

    void Update()
    {
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
        rot.y = rot.y + MouseX;

        transform.eulerAngles =  rot;
        player.transform.eulerAngles = new Vector3(0, rot.y, 0);
    }
}
