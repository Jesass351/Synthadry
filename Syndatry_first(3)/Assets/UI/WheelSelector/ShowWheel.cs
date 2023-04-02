using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowWheel : MonoBehaviour
{
    [SerializeField] private GameObject WheelUI;
    [SerializeField] private GameObject MainUI;

    [SerializeField] private float timeScale = 0.9f;
    // Start is called before the first frame update
    Camera mainCam;
    void Start()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            MainUI.SetActive(false);
            WheelUI.SetActive(true);
            Time.timeScale = timeScale;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
            Cursor.lockState = CursorLockMode.None;
            mainCam.GetComponent<CameraController>().sensitivityX = 0.02f; //будет Lerp и таким дерьмом не придётся заниматься, тк всё сделает Time.deltaTime
            mainCam.GetComponent<CameraController>().sensitivityY = 0.02f;

        }
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            WheelUI.SetActive(false);
            MainUI.SetActive(true);
            Time.timeScale = 1;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
            Cursor.lockState = CursorLockMode.Locked;
            mainCam.GetComponent<CameraController>().sensitivityX = 2;
            mainCam.GetComponent<CameraController>().sensitivityY = 2;

        }
    }
}
