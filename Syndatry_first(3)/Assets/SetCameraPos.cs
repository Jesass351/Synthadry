using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCameraPos : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        //transform.position = player.transform.position + new Vector3(0, +7.686f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + new Vector3(0, +7.686f, 0);
    }
}
