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

    private Vector3 initialCameraPosition;
    private float runOffset = 0.04f;
    Vector3 rot = new Vector3(0, 0, 0);

    private bool isIdle = false;
    private Coroutine resetCameraCoroutine;

    void Start()
    {
        initialCameraPosition = transform.localPosition;
    }

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

        transform.eulerAngles = rot;

        player.transform.eulerAngles = new Vector3(0, rot.y, 0);

        bool isRunning = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D);

        if (isRunning && !isIdle)
        {
            isIdle = true;

            if (resetCameraCoroutine != null)
            {
                StopCoroutine(resetCameraCoroutine);
            }

            Vector3 targetCameraPosition = initialCameraPosition;
            if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)) targetCameraPosition.z += runOffset;
            else if (Input.GetKey(KeyCode.A)) targetCameraPosition.x += runOffset;
            else if (Input.GetKey(KeyCode.D)) targetCameraPosition.x -= runOffset;
            transform.localPosition = targetCameraPosition;
        }
        else if (!isRunning && isIdle)
        {
            isIdle = false;
            resetCameraCoroutine = StartCoroutine(ResetCameraPosition());
        }
    }

    private IEnumerator ResetCameraPosition()
    {
        yield return new WaitForSeconds(0.1f);
        while(transform.localPosition != initialCameraPosition)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, initialCameraPosition, Time.deltaTime * 5);
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}