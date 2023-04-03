using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewUseCar : MonoBehaviour
{
    [SerializeField] private GameObject car;
    [SerializeField] private List<GameObject> wheelColliders;
    [SerializeField] private GameObject player;
    [SerializeField] private Transform outPos;
    [SerializeField] private GameObject carCamera;


    private bool canEnter = false;

    // Start is called before the first frame update
    void Start()
    {
        car.GetComponent<PrometeoCarController>().enabled = false;
        for (var i = 0; i < wheelColliders.Count; i++)
        {
            wheelColliders[i].SetActive(false);
        }
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (canEnter)
            {
                if (player.activeInHierarchy)
                {
                    player.SetActive(false);
                    carCamera.SetActive(true);
                    carCamera.GetComponent<CarCamera>().target = car.transform;
                    for (var i = 0; i < wheelColliders.Count; i++)
                    {
                        wheelColliders[i].SetActive(true);
                    }
                    car.GetComponent<PrometeoCarController>().enabled = true;
                }
                canEnter = false;


            }
            else
            {
                player.transform.position = outPos.position;
                player.SetActive(true);
                carCamera.SetActive(false);
                car.GetComponent<PrometeoCarController>().enabled = false;
                for (var i = 0; i < wheelColliders.Count; i++)
                {
                    wheelColliders[i].SetActive(false);
                }
                canEnter = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canEnter = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canEnter = false;
        }
    }
}
