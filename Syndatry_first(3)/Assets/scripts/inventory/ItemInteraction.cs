using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteraction : MonoBehaviour
{
    [SerializeField] private Transform cam;
    [SerializeField] private int takeDistance = 8;
    [SerializeField] private GameObject player;
    [SerializeField] LayerMask itemLayer;
    private InventorySystem inventorySystem;

    //[SerializeField] TextMeshProUGUI txt_HoveredItem;
    void Start()
    {
        inventorySystem = player.GetComponent<InventorySystem>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (Physics.Raycast(cam.position, cam.forward, out hit, takeDistance, itemLayer))
            {
                if (!hit.collider.GetComponent<ItemObject>())
                    return;

                Debug.Log(hit.collider.gameObject);

                inventorySystem.PickUpItem(hit.collider.gameObject);
            }
            else
            {
                //Ã¡  ¿ Œ…-“Œ «¬”  œ–Œ»√–€¬¿“‹?
            }
           
        }
        
    }
}