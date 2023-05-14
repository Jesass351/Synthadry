using EPOOutline;
using UnityEngine;

public class UseProjector : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject projectorCamera;
    [SerializeField] private GameObject outline;

    private bool canUse = false;

    // Update is called once per frame
    void Update()
    {
        if (canUse)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (player.activeInHierarchy)
                {
                    player.SetActive(false);
                    player.GetComponent<CustomCharacterController>().enabled = false;
                    projectorCamera.SetActive(true);
                    outline.GetComponent<Outlinable>().enabled = false;
                }
                else
                {
                    projectorCamera.SetActive(false);
                    player.SetActive(true);
                    player.GetComponent<CustomCharacterController>().enabled = true;
                    outline.GetComponent<Outlinable>().enabled = true;
                }
            }
        }
/*        if (Input.GetKeyDown(KeyCode.F))
        {
            if (canUse)
            {
                if (player.activeInHierarchy)
                {
                    player.SetActive(false);
                    player.GetComponent<CustomCharacterController>().enabled = false;
                    projectorCamera.SetActive(true);
                }
                canUse = false;
            }
            else
            {

            }
        }*/

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            canUse = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canUse = false;
        }
    }
}
