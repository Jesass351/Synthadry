using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseCar : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject carCamera;
    [SerializeField] private GameObject realCar;
    [SerializeField] private GameObject fakeCar;
    [SerializeField] private GameObject collider;
    [SerializeField] private Transform OutPoint;

    public bool canEnter = false;
    // Start is called before the first frame update
    void Start()
    {
        
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
                    realCar.SetActive(true);
                    carCamera.SetActive(true);
                    carCamera.GetComponent<CarCamera>().target = realCar.transform;
                    fakeCar.SetActive(false);
                }
                canEnter = false;


            }
            else
            {
                player.transform.position = OutPoint.position;
                player.SetActive(true);
                realCar.SetActive(false);
                carCamera.SetActive(false);
                fakeCar.transform.position = realCar.transform.position;
                fakeCar.transform.rotation = realCar.transform.rotation;
                collider.transform.position = realCar.transform.position;
                fakeCar.SetActive(true);
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
